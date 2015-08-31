using PokeD.Core.Interfaces;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.Remote.Authorization
{
    public class CompressionRequestPacket : IPacket
    {
        public uint Threshold { get; set; }

        public override int ID { get { return (int) RemotePacketTypes.CompressionRequestPacket; } }

        public override IPacket ReadPacket(IPokeDataReader reader)
        {
            Threshold = reader.ReadUInt();

            return this;
        }

        public override IPacket WritePacket(IPokeStream stream)
        {
            stream.WriteUInt(Threshold);

            return this;
        }
    }
}
