using PokeD.Core.Interfaces;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.Battle
{
    public class BattleHostDataPacket : IPacket
    {
        public int DestinationPlayerID { get { return int.Parse(DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }
        public string BattleData { get { return DataItems[1]; } set { DataItems[1] = value; } }


        public override int ID { get { return (int) PlayerPacketTypes.BattleHostData; } }

        public override IPacket ReadPacket(IPokeDataReader reader)
        {
            DestinationPlayerID = reader.ReadVarInt();
            BattleData = reader.ReadString();

            return this;
        }

        public override IPacket WritePacket(IPokeStream writer)
        {
            writer.WriteVarInt(DestinationPlayerID);
            writer.WriteString(BattleData);

            return this;
        }
    }
}
