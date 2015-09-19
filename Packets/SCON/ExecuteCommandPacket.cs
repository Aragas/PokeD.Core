using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON
{
    public class ExecuteCommandPacket : Packet
    {
        public string Command { get; set; }

        public override int ID => (int) SCONPacketTypes.ExecuteCommand;

        public override Packet ReadPacket(IPacketDataReader reader)
        {
            Command = reader.ReadString();

            return this;
        }

        public override Packet WritePacket(IPacketStream stream)
        {
            stream.WriteString(Command);

            return this;
        }
    }
}
