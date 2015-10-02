using System;

using PokeD.Core.Data;
using PokeD.Core.Extensions;
using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Shared
{
    public class GameDataPacket : P3DPacket
    {
        public string GameMode { get { return DataItems[0]; } set { DataItems[0] = value; } }
        public bool IsGameJoltPlayer { get { return int.Parse(DataItems[1], CultureInfo) == 1; } set { DataItems[1] = (value ? 1 : 2).ToString(CultureInfo); } }
        public ulong GameJoltID { get { return ulong.Parse(DataItems[2], CultureInfo); } set { DataItems[2] = value.ToString(CultureInfo); } }
        public char DecimalSeparator { get { return DataItems[3][0]; } set { DataItems[3] = value.ToString(); } }
        public string Name { get { return DataItems[4]; } set { DataItems[4] = value; } }
        public string LevelFile { get { return DataItems[5]; } set { DataItems[5] = value; } }
        private string Position { get { return DataItems[6]; } set { DataItems[6] = value; } }
        public int Facing { get { return int.Parse(DataItems[7], CultureInfo); } set { DataItems[7] = value.ToString(CultureInfo); } }
        public bool Moving { get { return int.Parse(DataItems[8], CultureInfo) == 1; } set { DataItems[8] = (value ? 1 : 2).ToString(CultureInfo); } }
        public string Skin { get { return DataItems[9]; } set { DataItems[9] = value; } }
        public string BusyType { get { return DataItems[10]; } set { DataItems[10] = value; } }
        public bool PokemonVisible { get { return int.Parse(DataItems[11], CultureInfo) == 1; } set { DataItems[11] = (value ? 1 : 2).ToString(CultureInfo); } }
        private string PokemonPosition { get { return DataItems[12]; } set { DataItems[12] = value; } }
        public string PokemonSkin { get { return DataItems[13]; } set { DataItems[13] = value; } }

        public int PokemonFacing { get { try { return int.Parse(DataItems[14], CultureInfo); } catch (Exception) { return 0; } } set { DataItems[14] = value.ToString(CultureInfo); } }


        public Vector3 GetPosition(char separator) { return Vector3Extensions.FromPokeString(Position, separator); }
        public void SetPosition(Vector3 position, char separator) { Position = position.ToPokeString(separator, CultureInfo); }

        //public Vector3 GetPokemonPosition(char separator) { return Vector3.FromPokeString(PokemonPosition, separator); }
        public Vector3 GetPokemonPosition(char separator) { return Vector3Extensions.FromPokeString(PokemonPosition, separator); }
        public void SetPokemonPosition(Vector3 position, char separator) { PokemonPosition = position.ToPokeString(separator, CultureInfo); }

        public override int ID => (int) GamePacketTypes.GameData;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            var length = reader.ReadVarInt();
            DataItems = new DataItems(reader.ReadStringArray(length));
            
            /*
            GameMode = reader.ReadString();
            IsGameJoltPlayer = reader.ReadBoolean();
            GameJoltId = reader.ReadULong();
            DecimalSeparator = (char) reader.ReadVarInt();
            Name = reader.ReadString();
            LevelFile = reader.ReadString();
            SetPosition(Vector3.FromReaderByte(reader), DecimalSeparator);
            Facing = reader.ReadVarInt();
            Moving = reader.ReadBoolean();
            Skin = reader.ReadString();
            BusyType = reader.ReadString();
            PokemonVisible = reader.ReadBoolean();
            SetPokemonPosition(Vector3.FromReaderByte(reader), DecimalSeparator);
            PokemonSkin = reader.ReadString();
            PokemonFacing = reader.ReadVarInt();
            */

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream writer)
        {
            var data = DataItems.ToArray();
            writer.WriteVarInt(data.Length);
            writer.WriteStringArray(data);
            
            /*
            writer.WriteString(GameMode);
            writer.WriteBoolean(IsGameJoltPlayer);
            writer.WriteULong(GameJoltId);
            writer.WriteVarInt(DecimalSeparator);
            writer.WriteString(Name);
            writer.WriteString(LevelFile);
            GetPosition(DecimalSeparator).ToStreamByte(writer);
            writer.WriteVarInt(Facing);
            writer.WriteBoolean(Moving);
            writer.WriteString(Skin);
            writer.WriteString(BusyType);
            writer.WriteBoolean(PokemonVisible);
            GetPokemonPosition(DecimalSeparator).ToStreamByte(writer);
            writer.WriteString(PokemonSkin);
            writer.WriteVarInt(PokemonFacing);
            */

            return this;
        }
    }
}
