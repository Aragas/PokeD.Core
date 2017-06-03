﻿using System.Collections.Generic;

using Aragas.Network.Attributes;

using PokeD.Core.IO;

namespace PokeD.Core.Packets.P3D.Server
{
    [Packet((int) P3DPacketTypes.ServerInfoData)]
    public class ServerInfoDataPacket : P3DPacket
    {
        public int CurrentPlayers { get { return int.Parse(DataItems[0] == string.Empty ? 0.ToString() : DataItems[0]); } set { DataItems[0] = value.ToString(); } }
        public int MaxPlayers { get { return int.Parse(DataItems[1] == string.Empty ? 0.ToString() : DataItems[1]); } set { DataItems[1] = value.ToString(); } }
        public string ServerName { get { return DataItems[2]; } set { DataItems[2] = value; } }
        public string ServerMessage { get { return DataItems[3]; } set { DataItems[3] = value; } }
        public string[] PlayerNames
        {
            get
            {
                if (DataItems.Length > 4)
                {
                    var list = new List<string>();
                    for (var i = 4; i < DataItems.Length; i++)
                        list.Add(DataItems[i]);

                    return list.ToArray();
                }

                return new string[0];
            }
            set
            {
                if (value != null)
                {
                    for (var i = 0; i < value.Length; i++)
                        DataItems[4 + i] = value[i];
                }
            }
        }


        public override void Deserialize(P3DDeserializer deserialiser) { }
        public override void Serialize(P3DSerializer serializer) { }
    }
}
