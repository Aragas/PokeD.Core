using PokeD.Core.Data;
using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Status
{
    public class PlayerLocationResponsePacket : ProtobufPacket
    {
        public string Player { get; set; }
        public Vector3 Position { get; set; }
        public string LevelFile { get; set; }

        public override int ID => (int) SCONPacketTypes.PlayerLocationResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            Player = reader.ReadString();
            Position = Vector3.FromReaderByte(reader);
            LevelFile = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.WriteString(Player);
            Position.ToStreamByte(stream);
            stream.WriteString(LevelFile);

            return this;
        }
    }
}
