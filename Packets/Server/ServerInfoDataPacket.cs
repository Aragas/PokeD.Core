using PokeD.Core.Interfaces;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.Server
{
    public class ServerInfoDataPacket : IPacket
    {
        public int CurrentPlayers { get { return int.Parse(DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }
        public int MaxPlayers { get { return int.Parse(DataItems[1], CultureInfo); } set { DataItems[1] = value.ToString(CultureInfo); } }
        public string ServerName { get { return DataItems[2]; } set { DataItems[2] = value; } }
        public string ServerMessage { get { return DataItems[3]; } set { DataItems[3] = value; } }


        public override int ID { get { return (int) PacketTypes.ServerInfoData; } }

        public override IPacket ReadPacket(IPokeDataReader reader)
        {
            CurrentPlayers = reader.ReadVarInt();
            MaxPlayers = reader.ReadVarInt();
            ServerName = reader.ReadString();
            ServerMessage = reader.ReadString();

            return this;
        }

        public override IPacket WritePacket(IPokeStream writer)
        {
            writer.WriteVarInt(CurrentPlayers);
            writer.WriteVarInt(MaxPlayers);
            writer.WriteString(ServerName);
            writer.WriteString(ServerMessage);

            return this;
        }
    }
}
