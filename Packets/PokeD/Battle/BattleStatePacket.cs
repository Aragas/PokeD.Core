using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

using PokeD.Core.Data.PokeD.Battle;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Server
    /// </summary>
    public class BattleStatePacket : PokeDPacket
    {
        public BattleState BattleState { get; set; } = new BattleState();


        public override VarInt ID => PokeDPacketTypes.BattleState;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            BattleState = reader.Read(BattleState);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream writer)
        {
            //writer.Write(BattleState);

            return this;
        }
    }
}
