using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

using PokeD.Core.Data.PokeD.Structs;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Client
    /// </summary>
    public class BattleSwitchPacket : PokeDPacket
    {
        private MetaSwitch Info { get; set; }
        public byte CurrentMonster { get { return Info.CurrentMonster; } set { Info = new MetaSwitch(value, SwitchMonster); } }
        public byte SwitchMonster { get { return Info.SwitchMonster; } set { Info = new MetaSwitch(CurrentMonster, value); } }


        public override VarInt ID => PokeDPacketTypes.BattleSwitch;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            Info = reader.Read(Info);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream writer)
        {
            writer.Write(Info);

            return this;
        }
    }
}
