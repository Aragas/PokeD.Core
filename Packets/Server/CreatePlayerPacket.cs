using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Server
{
    public class CreatePlayerPacket : P3DPacket
    {
        public int PlayerID { get { return int.Parse(DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }


        public override int ID => (int) GamePacketTypes.CreatePlayer;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            PlayerID = reader.ReadVarInt();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream writer)
        {
            writer.WriteVarInt(PlayerID);

            return this;
        }
    }
}
