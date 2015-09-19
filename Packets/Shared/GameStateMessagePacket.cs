using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Shared
{
    public class GameStateMessageP3DPacket : P3DPacket
    {
        public string EventMessage {  get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override int ID => (int) PlayerPacketTypes.GameStateMessage;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            EventMessage = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream writer)
        {
            writer.WriteString(EventMessage);

            return this;
        }
    }
}
