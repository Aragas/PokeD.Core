using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerLocationRequestPacket : ProtobufPacket
    {
        public string Player { get; set; }

        public override int ID => (int) SCONPacketTypes.PlayerLocationRequest;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            Player = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.WriteString(Player);

            return this;
        }
    }
}
