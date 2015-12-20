using Aragas.Core.IO;
using Aragas.Core.Packets;
using Aragas.Core.Wrappers;

using PokeD.Core.Packets;

namespace PokeD.Core.IO
{
    public class ProtobufOriginStream : ProtobufStream
    {
        public ProtobufOriginStream(ITCPClient tcp, bool isServer = false) : base(tcp, isServer) { }

        public override void SendPacket(ref ProtobufPacket packet)
        {
            var originPacket = packet as ProtobufOriginPacket;

            Write(originPacket.ID);
            Write(originPacket.Origin);
            packet.WritePacket(this);
            Purge();
        }
    }
}
