using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Server
    /// </summary>
    public class BattleOfferPacket : P3DPacket
    {
        public VarInt[] PlayerIDs { get; set; } // First is Player that has offered battle
        public string Message { get; set; }


        public override VarInt ID => (int) P3DPacketTypes.BattleOffer;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            PlayerIDs = reader.Read(PlayerIDs);
            Message = reader.Read(Message);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(PlayerIDs);
            writer.Write(Message);

            return this;
        }
    }
}
