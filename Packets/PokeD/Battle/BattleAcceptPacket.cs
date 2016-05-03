using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Client
    /// </summary>
    public class BattleAcceptPacket : PokeDPacket
    {
        public bool IsAccepted { get; set; }


        public override VarInt ID => PokeDPacketTypes.BattleAccept;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            IsAccepted = reader.Read(IsAccepted);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream writer)
        {
            writer.Write(IsAccepted);

            return this;
        }
    }
}
