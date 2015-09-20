using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogListResponsePacket : ProtobufPacket
    {
        public string[] LogFileList { get; set; }

        public override int ID => (int) SCONPacketTypes.LogListResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            var length = reader.ReadVarInt();
            LogFileList = reader.ReadStringArray(length);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.WriteVarInt(LogFileList.Length);
            stream.WriteStringArray(LogFileList);

            return this;
        }
    }
}
