using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Server
    /// </summary>
    public class BattleOfferPacket : PokeDPacket
    {
        public VarInt[] PlayerIDs { get; set; } = new VarInt[0];
        public string Message { get; set; } = string.Empty;


        public override VarInt ID => PokeDPacketTypes.BattleOffer;

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
