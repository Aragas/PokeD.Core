using System;

using Aragas.Network.Attributes;
using Aragas.Network.Data;

using PokeD.Core.Extensions;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.P3D.Shared
{
    [Packet((int) P3DPacketTypes.GameData)]
    public class GameDataPacket : P3DPacket
    {
        public string GameMode { get { return DataItems[0]; } set { DataItems[0] = value; } }
        public bool IsGameJoltPlayer { get { return int.Parse(DataItems[1], CultureInfo) == 1; } set { DataItems[1] = (value ? 1 : 2).ToString(CultureInfo); } }
        public long GameJoltID { get { return long.Parse(DataItems[2], CultureInfo); } set { DataItems[2] = value.ToString(CultureInfo); } }
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


        public Vector3 GetPosition(char separator) { return Vector3Extensions.FromPokeString(Position, separator, CultureInfo); }
        public void SetPosition(Vector3 position, char separator) { Position = position.ToPokeString(separator, CultureInfo); }

        public Vector3 GetPokemonPosition(char separator) { return Vector3Extensions.FromPokeString(PokemonPosition, separator, CultureInfo); }
        public void SetPokemonPosition(Vector3 position, char separator) { PokemonPosition = position.ToPokeString(separator, CultureInfo); }


        public override P3DPacket ReadPacket(P3DDataReader reader) { return this; }
        public override P3DPacket WritePacket(P3DStream writer) { return this; }
    }
}
