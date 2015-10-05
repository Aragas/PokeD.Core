using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON
{
    public class ExecuteCommandPacket : ProtobufPacket
    {
        public string Command { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.ExecuteCommand;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            Command = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.Write(Command);

            return this;
        }
    }
}
