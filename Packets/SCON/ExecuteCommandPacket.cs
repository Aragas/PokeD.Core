using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON
{
    public class ExecuteCommandPacket : ProtobufPacket
    {
        public string Command;

        public override VarInt ID => (int) SCONPacketTypes.ExecuteCommand;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            Command = reader.Read(Command);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream stream)
        {
            stream.Write(Command);

            return this;
        }
    }
}
