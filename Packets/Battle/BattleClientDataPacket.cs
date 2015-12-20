using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Battle
{
    public class BattleClientDataPacket : P3DPacket
    {
        public VarInt DestinationPlayerID { get { return VarInt.Parse(DataItems[0] == string.Empty ? 0.ToString() : DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }
        public string BattleData { get { return DataItems[1]; } set { DataItems[1] = value; } }


        public override VarInt ID => (int) GamePacketTypes.BattleClientData;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            if(reader.IsServer)
                DestinationPlayerID = reader.Read(DestinationPlayerID);
            
            BattleData = reader.Read(BattleData);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            if(!writer.IsServer)
                writer.Write(DestinationPlayerID);
            writer.Write(BattleData);

            return this;
        }
    }
}
