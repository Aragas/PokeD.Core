using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Server
{
    public class ServerMessagePacket : P3DPacket
    {
        public string Message { get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override int ID => (int) GamePacketTypes.ServerMessage;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            Message = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream writer)
        {
            writer.WriteString(Message);

            return this;
        }
    }
}
