using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON
{
    public class ExecuteCommandPacket : ProtobufPacket
    {
        public string Command { get; set; }

        public override int ID => (int) SCONPacketTypes.ExecuteCommand;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            Command = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.WriteString(Command);

            return this;
        }
    }
}
