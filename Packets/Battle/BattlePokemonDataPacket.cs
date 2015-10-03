using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Battle
{
    public class BattlePokemonDataPacket : P3DPacket
    {
        public int DestinationPlayerID { get { return int.Parse(DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }
        public string BattleData { get { return DataItems[1]; } set { DataItems[1] = value; } }


        public override int ID => (int) GamePacketTypes.BattlePokemonData;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            if (reader.IsServer)
                DestinationPlayerID = reader.ReadVarInt();
            BattleData = reader.ReadString();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream writer)
        {
            if (!writer.IsServer)
                writer.WriteVarInt(DestinationPlayerID);
            writer.WriteString(BattleData);

            return this;
        }
    }
}
