using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Server
    /// </summary>
    public class BattleOfferPacket : PokeDPacket
    {
        public VarInt[] PlayerIds { get; set; } = new VarInt[0];
        public string Message { get; set; } = string.Empty;


        public override VarInt ID => PokeDPacketTypes.BattleOffer;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            PlayerIds = reader.Read(PlayerIds);
            Message = reader.Read(Message);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream writer)
        {
            writer.Write(PlayerIds);
            writer.Write(Message);

            return this;
        }
    }
}
