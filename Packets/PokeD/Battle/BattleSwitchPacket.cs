using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

using PokeD.Core.Data.PokeD.Structs;
using PokeD.Core.Extensions;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Client
    /// </summary>
    public class BattleSwitchPacket : PokeDPacket
    {
        private MetaSwitch Info { get; set; }
        public byte CurrentMonster { get { return Info.CurrentMonster; } set { Info.CurrentMonster = value; } }
        public byte SwitchMonster { get { return Info.SwitchMonster; } set { Info.SwitchMonster = value; } }


        public override VarInt ID => (int) PokeDPacketTypes.BattleSwitch;

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
