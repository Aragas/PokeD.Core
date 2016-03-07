using Aragas.Core.IO;

namespace PokeD.Core.Packets.P3D.Encryption
{
    public class JoiningGameRequestPacket : P3DPacket
    {
        public override int ID => (int) P3DPacketTypes.JoiningGameRequest;

        public override P3DPacket ReadPacket(PacketDataReader reader)
        {
            return this;
        }

        public override P3DPacket WritePacket(PacketStream stream)
        {
            return this;
        }
    }
}
