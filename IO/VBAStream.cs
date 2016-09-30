using System;

using Aragas.Network.IO;
using Aragas.Network.Packets;

using PCLExt.Network;

namespace PokeD.Core.IO
{
    public class VBAStream : StandardStream
    {
        public VBAStream(ISocketClient socket, bool isServer = false) : base(socket, isServer) { }

        public override void SendPacket(Packet packet)
        {
            var standartPacket = packet as StandardPacket;
            if (standartPacket != null)
            {
                Write((byte) standartPacket.ID);
                standartPacket.WritePacket(this);
            }

            var standartPacketA = packet as StandardPacketAttribute;
            if (standartPacketA != null)
            {
                Write((byte) standartPacketA.ID);
                standartPacketA.WritePacket(this);
            }


            Purge();
        }

        protected override void Purge()
        {
            var lenBytes = new byte[] { (byte) (_buffer.Length + 1) };
            var tempBuff = new byte[_buffer.Length + lenBytes.Length];

            Array.Copy(lenBytes, 0, tempBuff, 0, lenBytes.Length);
            Array.Copy(_buffer, 0, tempBuff, lenBytes.Length, _buffer.Length);


            Send(tempBuff);
            _buffer = null;
        }
    }
}
