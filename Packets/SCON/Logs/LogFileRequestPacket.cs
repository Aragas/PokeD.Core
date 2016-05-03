using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.SCON.Logs
{
    public class LogFileRequestPacket : SCONPacket
    {
        public string LogFilename { get; set; } = string.Empty;


        public override VarInt ID => SCONPacketTypes.LogFileRequest;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            LogFilename = reader.Read(LogFilename);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(LogFilename);

            return this;
        }
    }
}
