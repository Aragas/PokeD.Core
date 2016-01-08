using System.Collections.Generic;

using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.P3D.Server
{
    public class ServerInfoDataPacket : P3DPacket
    {
        public VarInt CurrentPlayers { get { return VarInt.Parse(DataItems[0] == string.Empty ? 0.ToString() : DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }
        public VarInt MaxPlayers { get { return VarInt.Parse(DataItems[1] == string.Empty ? 0.ToString() : DataItems[1], CultureInfo); } set { DataItems[1] = value.ToString(CultureInfo); } }
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


        public override VarInt ID => (int) P3DPacketTypes.ServerInfoData;

        public override ProtobufPacket ReadPacket(PacketDataReader reader)
        {
            CurrentPlayers = reader.Read(CurrentPlayers);
            MaxPlayers = reader.Read(MaxPlayers);
            ServerName = reader.Read(ServerName);
            ServerMessage = reader.Read(ServerMessage);
            PlayerNames = reader.Read(PlayerNames);

            return this;
        }

        public override ProtobufPacket WritePacket(PacketStream writer)
        {
            writer.Write(CurrentPlayers);
            writer.Write(MaxPlayers);
            writer.Write(ServerName);
            writer.Write(ServerMessage);
            writer.Write(PlayerNames);

            return this;
        }
    }
}
