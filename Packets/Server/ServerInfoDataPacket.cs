using System.Collections.Generic;

using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.Server
{
    public class ServerInfoDataPacket : P3DPacket
    {
        public int CurrentPlayers { get { return int.Parse(DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }
        public int MaxPlayers { get { return int.Parse(DataItems[1], CultureInfo); } set { DataItems[1] = value.ToString(CultureInfo); } }
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


        public override int ID => (int) GamePacketTypes.ServerInfoData;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            CurrentPlayers = reader.ReadVarInt();
            MaxPlayers = reader.ReadVarInt();
            ServerName = reader.ReadString();
            ServerMessage = reader.ReadString();
            var length = reader.ReadVarInt();
            PlayerNames = reader.ReadStringArray(length);

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream writer)
        {
            writer.WriteVarInt(CurrentPlayers);
            writer.WriteVarInt(MaxPlayers);
            writer.WriteString(ServerName);
            writer.WriteString(ServerMessage);
            writer.WriteVarInt(PlayerNames.Length);
            writer.WriteStringArray(PlayerNames);

            return this;
        }
    }
}
