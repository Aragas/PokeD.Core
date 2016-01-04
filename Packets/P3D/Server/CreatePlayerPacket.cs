using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.P3D.Server
{
    public class CreatePlayerPacket : P3DPacket
    {
        public VarInt PlayerID { get { return VarInt.Parse(DataItems[0] == string.Empty ? 0.ToString() : DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }


        public override VarInt ID => (int) P3DPacketTypes.CreatePlayer;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            PlayerID = reader.Read(PlayerID);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(PlayerID);

            return this;
        }
    }
}
