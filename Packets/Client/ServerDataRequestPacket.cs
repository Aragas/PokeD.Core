using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Client
{
    public class ServerDataRequestPacket : P3DPacket
    {
        public string DontEvenKnow { get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override int ID => (int) GamePacketTypes.ServerDataRequest;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            DontEvenKnow = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream writer)
        {
            writer.WriteString(DontEvenKnow);

            return this;
        }
    }
}
