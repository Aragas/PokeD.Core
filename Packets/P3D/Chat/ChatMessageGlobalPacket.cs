using PokeD.Core.IO;

namespace PokeD.Core.Packets.P3D.Chat
{
    public class ChatMessageGlobalPacket : P3DPacket
    {
        public string Message { get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override int ID => (int) P3DPacketTypes.ChatMessageGlobal;

        public override P3DPacket ReadPacket(P3DDataReader reader) { return this; }
        public override P3DPacket WritePacket(P3DStream writer) { return this; }
    }
}
