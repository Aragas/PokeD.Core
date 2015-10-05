using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogFileRequestPacket : ProtobufPacket
    {
        public string LogFilename { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.LogFileRequest;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            LogFilename = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.Write(LogFilename);

            return this;
        }
    }
}
