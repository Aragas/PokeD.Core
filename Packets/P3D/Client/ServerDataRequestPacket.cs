using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.P3D.Client
{
    public class ServerDataRequestPacket : P3DPacket
    {
        public string DontEvenKnow { get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override VarInt ID => (int) P3DPacketTypes.ServerDataRequest;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            DontEvenKnow = reader.Read(DontEvenKnow);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(DontEvenKnow);

            return this;
        }
    }
}
