using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Server
{
    public class IDPacket : P3DPacket
    {
        public int PlayerID { get { return int.Parse(DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }


        public override int ID => (int) GamePacketTypes.ID;

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
