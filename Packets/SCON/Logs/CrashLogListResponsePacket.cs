using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class CrashLogListResponsePacket : ProtobufPacket
    {
        public string[] CrashLogFileList { get; set; }

        public override int ID => (int) SCONPacketTypes.CrashLogListResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            var length = reader.ReadVarInt();
            CrashLogFileList = reader.ReadStringArray(length);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.WriteVarInt(CrashLogFileList.Length);
            stream.WriteStringArray(CrashLogFileList);

            return this;
        }
    }
}
