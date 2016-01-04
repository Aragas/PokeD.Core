using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.P3D.Shared
{
    public class GameStateMessagePacket : P3DPacket
    {
        public string EventMessage {  get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override VarInt ID => (int) P3DPacketTypes.GameStateMessage;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            EventMessage = reader.Read(EventMessage);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(EventMessage);

            return this;
        }
    }
}
