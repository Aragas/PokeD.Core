using Aragas.Network.Attributes;

using PokeD.Core.IO;

namespace PokeD.Core.Packets.P3D.Battle
{
    [Packet((int) P3DPacketTypes.BattleHostData)]
    public class BattleHostDataPacket : P3DPacket
    {
        public int DestinationPlayerID { get { return int.Parse(DataItems[0] == string.Empty ? 0.ToString() : DataItems[0]); } set { DataItems[0] = value.ToString(); } }
        public string BattleData { get { return DataItems[1]; } set { DataItems[1] = value; } }

        public override void Deserialize(P3DDeserializer deserialiser) { }
        public override void Serialize(P3DSerializer serializer) { }
    }
}
