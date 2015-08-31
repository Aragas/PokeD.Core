using System;
using PokeD.Core.Data;
using PokeD.Core.Interfaces;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.Shared
{
    public class GameDataPacket : IPacket
    {
        public string GameMode { get { return DataItems[0]; } set { DataItems[0] = value; } }
        public bool IsGameJoltPlayer { get { return int.Parse(DataItems[1], CultureInfo) == 1; } set { DataItems[1] = (value ? 1 : 2).ToString(CultureInfo); } }
        public long GameJoltId { get { return long.Parse(DataItems[2], CultureInfo); } set { DataItems[2] = value.ToString(CultureInfo); } }
        public char DecimalSeparator { get { return DataItems[3][0]; } set { DataItems[3] = value.ToString(); } }
        public string Name { get { return DataItems[4]; } set { DataItems[4] = value; } }
        public string LevelFile { get { return DataItems[5]; } set { DataItems[5] = value; } }
        public Vector3 Position { get { return Vector3.FromPokeString(DataItems[6]); } set { DataItems[0] = value.ToPokeString(); } }
        public int Facing { get { return int.Parse(DataItems[7], CultureInfo); } set { DataItems[7] = value.ToString(CultureInfo); } }
        public bool Moving { get { return int.Parse(DataItems[8], CultureInfo) == 1; } set { DataItems[8] = (value ? 1 : 2).ToString(CultureInfo); } }
        public string Skin { get { return DataItems[9]; } set { DataItems[9] = value; } }
        public string BusyType { get { return DataItems[10]; } set { DataItems[10] = value; } }
        public bool PokemonVisible { get { return int.Parse(DataItems[11], CultureInfo) == 1; } set { DataItems[11] = (value ? 1 : 2).ToString(CultureInfo); } }
        public Vector3 PokemonPosition { get { return Vector3.FromPokeString(DataItems[12]); } set { DataItems[12] = value.ToPokeString(); } }
        public string PokemonSkin { get { return DataItems[13]; } set { DataItems[13] = value; } }

        public int PokemonFacing { get { try { return int.Parse(DataItems[14], CultureInfo); } catch (Exception) { return 0; } } set { DataItems[14] = value.ToString(CultureInfo); } }


        public override int ID { get { return (int) PlayerPacketTypes.GameData; } }

        public override IPacket ReadPacket(IPokeDataReader reader)
        {
            GameMode = reader.ReadString();
            IsGameJoltPlayer = reader.ReadBoolean();
            GameJoltId = reader.ReadVarInt();
            DecimalSeparator = reader.ReadString()[0];
            Name = reader.ReadString();
            LevelFile = reader.ReadString();
            Position = Vector3.FromReaderByte(reader);
            Facing = reader.ReadVarInt();
            Moving = reader.ReadBoolean();
            Skin = reader.ReadString();
            BusyType = reader.ReadString();
            PokemonVisible = reader.ReadBoolean();
            PokemonPosition = Vector3.FromReaderByte(reader);
            PokemonSkin = reader.ReadString();
            PokemonFacing = reader.ReadVarInt();

            return this;
        }

        public override IPacket WritePacket(IPokeStream writer)
        {
            writer.WriteString(GameMode);
            writer.WriteBoolean(IsGameJoltPlayer);
            writer.WriteLong(GameJoltId);
            writer.WriteVarInt(DecimalSeparator);
            writer.WriteString(Name);
            writer.WriteString(LevelFile);
            Position.ToStreamByte(writer);
            writer.WriteVarInt(Facing);
            writer.WriteBoolean(Moving);
            writer.WriteString(Skin);
            writer.WriteString(BusyType);
            writer.WriteBoolean(PokemonVisible);
            PokemonPosition.ToStreamByte(writer);
            writer.WriteString(PokemonSkin);
            writer.WriteVarInt(PokemonFacing);

            return this;
        }
    }
}
