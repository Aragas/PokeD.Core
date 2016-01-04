using System;
using Aragas.Core.Data;

namespace PokeD.Core.Data.SCON
{
    public class PlayerInfo
    {
        public string Name;
        public long GameJoltID;
        public string IP;
        public ushort Ping;
        public Vector3 Position;
        public string LevelFile;
        public TimeSpan PlayTime;
    }
}