﻿using Aragas.Network.IO;

using PokeD.Core.Data.PokeD.Structs;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Client
    /// </summary>
    public class BattleSwitchPacket : PokeDPacket
    {
        private MetaSwitch Info { get; set; }
        public byte CurrentMonster { get => Info.CurrentMonster; set => Info = new MetaSwitch(value, SwitchMonster); }
        public byte SwitchMonster { get => Info.SwitchMonster; set => Info = new MetaSwitch(CurrentMonster, value); }


        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            Info = deserialiser.Read(Info);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(Info);
        }
    }
}
