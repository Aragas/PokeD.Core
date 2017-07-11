﻿using Aragas.Network.Attributes;

using PokeD.Core.Data.P3D;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.P3D.Battle
{
    [Packet((int) P3DPacketTypes.BattleEndRoundData)]
    public class BattleEndRoundDataPacket : P3DPacket
    {
        public int DestinationPlayerID { get => int.Parse(DataItems[0] == string.Empty ? 0.ToString() : DataItems[0]); set => DataItems[0] = value.ToString(); }
        public BattleEndRoundData BattleData { get => DataItems[1]; set => DataItems[1] = value; }

        public override void Deserialize(P3DDeserializer deserialiser) { }
        public override void Serialize(P3DSerializer serializer) { }
    }
}
