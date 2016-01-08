using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Client
    /// </summary>
    public class BattleAcceptPacket : PokeDPacket
    {
        public bool IsAccepted { get; set; }


        public override VarInt ID => (int) PokeDPacketTypes.BattleAccept;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            IsAccepted = reader.Read(IsAccepted);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(IsAccepted);

            return this;
        }
    }
}
