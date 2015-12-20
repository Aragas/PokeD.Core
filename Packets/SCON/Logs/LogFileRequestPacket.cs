using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogFileRequestPacket : ProtobufPacket
    {
        public string LogFilename;

        public override VarInt ID => (int) SCONPacketTypes.LogFileRequest;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            LogFilename = reader.Read(LogFilename);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            stream.Write(LogFilename);

            return this;
        }
    }
}
