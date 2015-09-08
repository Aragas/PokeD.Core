using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Remote.Authorization
{
    public class CompressionResponsePacket : Packet
    {
        public uint Threshold { get; set; }

        public override int ID => (int) RemotePacketTypes.CompressionResponsePacket;

        public override Packet ReadPacket(IPacketDataReader reader)
        {
            Threshold = reader.ReadUInt();

            return this;
        }

        public override Packet WritePacket(IPacketStream stream)
        {
            stream.WriteUInt(Threshold);

            return this;
        }
    }
}
