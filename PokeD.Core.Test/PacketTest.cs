using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

using NUnit.Framework;

using PokeD.Core.Data.PokeApi;
using PokeD.Core.Extensions;
using PokeD.Core.IO;
using PokeD.Core.Packets;

namespace PokeD.Core.Test
{
    [TestFixture]
    public class PacketTest
    {
        public PacketTest()
        {
            PokeApiV2.CacheData = true;

            PacketExtensions.Init();
        }


        [Test]
        public void TestP3DProtobufSerializationDeserialization()
        {
            var packets = P3DPacketResponses.Packets.Where(packetFunc => packetFunc != null).Select(packetFunc => packetFunc()).ToList();
            var testPackets = new List<P3DPacket>();

            var tcpClient = new TestITCPClient();
            using (var write = new P3DStream(tcpClient))
            {
                foreach (var packet in packets)
                    write.SendPacket(packet);


                tcpClient.Stream.Seek(0, SeekOrigin.Begin);


                string data;
                while (!string.IsNullOrEmpty((data = write.ReadLine())))
                    testPackets.Add(GetPacket(data));

                Assert.IsTrue(packets.Count == testPackets.Count);
                for (var i = 0; i < packets.Count; i++)
                    Assert.IsTrue(packets[i].ID == testPackets[i].ID);
            }
        }
        private static P3DPacket GetPacket(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                int id;
                if (P3DPacket.TryParseID(data, out id))
                {
                    if (P3DPacketResponses.Packets.Length > id)
                    {
                        if (P3DPacketResponses.Packets[id] != null)
                        {
                            var packet = P3DPacketResponses.Packets[id]();
                            if (packet.TryParseData(data))
                                return packet;
                            else
                                Assert.Fail();
                        }
                        else
                            Assert.Fail();
                    }
                    else
                        Assert.Fail();
                }
                else
                    Assert.Fail();
            }
            else
                Assert.Fail();

            return null;
        }


        [Test]
        public void TestPokeDProtobufSerializationDeserialization() { SerializationDeserialization(PokeDPacketResponses.Packets); }

        [Test]
        public void TestSCONProtobufSerializationDeserialization() { SerializationDeserialization(SCONPacketResponses.Packets); }
        
        private void SerializationDeserialization<TPacketType>(Func<TPacketType>[] packetFuncs) where TPacketType : ProtobufPacket
        {
            var packets = packetFuncs.Where(packetFunc => packetFunc != null).Select(packetFunc => packetFunc()).ToList();
            var testPackets = new List<TPacketType>();

            var tcpClient = new TestITCPClient();
            using (var write = new ProtobufStream(tcpClient))
            {
                foreach (var packet in packets)
                    write.SendPacket(packet);


                tcpClient.Stream.Seek(0, SeekOrigin.Begin);


                while (tcpClient.Stream.Position != tcpClient.Stream.Length)
                {
                    int length = write.ReadVarInt();
                    var byteArray = write.Receive(length);
                    testPackets.Add((TPacketType) GetPacket(byteArray, packetFuncs));
                }

                Assert.IsTrue(packets.Count == testPackets.Count);
                for (var i = 0; i < packets.Count; i++)
                    Assert.IsTrue(packets[i].ID == testPackets[i].ID);
            }
        }
        private static ProtobufPacket GetPacket<TPacketType>(byte[] byteArray, Func<TPacketType>[] packetFuncs) where TPacketType : ProtobufPacket
        {
            using (var reader = new ProtobufDataReader(byteArray))
            {
                var id = reader.Read<VarInt>();

                if (packetFuncs.Length > id)
                {
                    if (packetFuncs[id] != null)
                        return packetFuncs[id]().ReadPacket(reader);
                    else
                        Assert.Fail();
                }
                else
                    Assert.Fail();
            }

            return null;
        }
    }
}