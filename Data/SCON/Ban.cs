﻿using System;

namespace PokeD.Core.Data.SCON
{
    public class Ban
    {
        public string Name;
        public ulong GameJoltID;
        public string IP;
        public DateTime BanTime;
        public DateTime UnBanTime;
        public string Reason;
    }
}