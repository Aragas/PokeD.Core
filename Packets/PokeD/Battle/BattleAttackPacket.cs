using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

using PokeD.Core.Data.PokeD;
using PokeD.Core.Extensions;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Client
    /// </summary>
    public class BattleAttackPacket : P3DPacket
    {
        private MetaAttack Info { get; set; }

        public byte CurrentMonster { get { return Info.CurrentMonster; } set { Info.CurrentMonster = value; } }
        public byte Move { get { return Info.Move; } set { Info.Move = value; } }
        public byte TargetMonster { get { return Info.TargetMonster; } set { Info.TargetMonster = value; } }


        public override VarInt ID => (int) P3DPacketTypes.BattleHostData;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            Info = reader.Read(Info);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(Info);
            
            return this;
        }
    }
}
