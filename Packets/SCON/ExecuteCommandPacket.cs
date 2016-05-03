using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.SCON
{
    public class ExecuteCommandPacket : SCONPacket
    {
        public string Command { get; set; } = string.Empty;


        public override VarInt ID => SCONPacketTypes.ExecuteCommand;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            Command = reader.Read(Command);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(Command);

            return this;
        }
    }
}
