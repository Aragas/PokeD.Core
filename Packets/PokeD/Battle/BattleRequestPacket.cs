using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Client
    /// </summary>
    public class BattleRequestPacket : PokeDPacket
    {
        public VarInt[] PlayerIDs { get; set; } // First is Player that has offered battle, Include your own.
        public string Message { get; set; }


        public override VarInt ID => PokeDPacketTypes.BattleRequest;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            PlayerIDs = reader.Read(PlayerIDs);
            Message = reader.Read(Message);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream writer)
        {
            writer.Write(PlayerIDs);
            writer.Write(Message);

            return this;
        }
    }
}
