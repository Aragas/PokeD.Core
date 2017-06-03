using System;

using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Overworld
{
    public class WorldInfoPacket : PokeDPacket
    {
        public TimeSpan Time { get; set; }
        public byte Season { get; set; }
        public byte Weather { get; set; }
        public byte Event { get; set; }


        public override VarInt ID => PokeDPacketTypes.WorldInfo;

        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            Time = deserialiser.Read(Time);
            Season = deserialiser.Read(Season);
            Weather = deserialiser.Read(Weather);
            Event = deserialiser.Read(Event);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(Time);
            serializer.Write(Season);
            serializer.Write(Weather);
            serializer.Write(Event);
        }
    }
}
