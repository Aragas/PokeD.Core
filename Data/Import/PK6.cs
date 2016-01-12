using System;
using System.Linq;
using System.Text;

namespace PKHeX
{
    public class PK6
    {
        private const int SIZE_PARTY = 0x104;
        private const int SIZE_STORED = 0xE8;

        // Internal Attributes set on creation
        private byte[] Data; // Raw Storage


        public PK6(byte[] decryptedData)
        {
            if(decryptedData == null)
                throw new NullReferenceException($"{nameof(decryptedData)} is null.");

            Data = decryptedData;

            if (Data.Length != SIZE_PARTY)
                Array.Resize(ref Data, SIZE_PARTY);
        }


        // Structure
        #region Block A
        public uint EncryptionConstant => BitConverter.ToUInt32(Data, 0x00);
        public ushort Sanity => BitConverter.ToUInt16(Data, 0x04); // Should always be zero...
        public ushort Checksum { get { return BitConverter.ToUInt16(Data, 0x06); } private set { BitConverter.GetBytes(value).CopyTo(Data, 0x06); } }
        public int Species => BitConverter.ToUInt16(Data, 0x08);
        public int HeldItem => BitConverter.ToUInt16(Data, 0x0A);
        public int TID => BitConverter.ToUInt16(Data, 0x0C);
        public int SID => BitConverter.ToUInt16(Data, 0x0E);
        public uint EXP => BitConverter.ToUInt32(Data, 0x10);
        public int Ability => Data[0x14];
        public int AbilityNumber => Data[0x15];
        public int TrainingBagHits => Data[0x16];
        public int TrainingBag => Data[0x17];
        public uint PID => BitConverter.ToUInt32(Data, 0x18);
        public int Nature => Data[0x1C];
        public bool FatefulEncounter => (Data[0x1D] & 1) == 1;
        public int Gender => (Data[0x1D] >> 1) & 0x3;
        public int AltForm => Data[0x1D] >> 3;
        public int EV_HP => Data[0x1E];
        public int EV_ATK => Data[0x1F];
        public int EV_DEF => Data[0x20];
        public int EV_SPE => Data[0x21];
        public int EV_SPA => Data[0x22];
        public int EV_SPD => Data[0x23];
        public int CNT_Cool => Data[0x24];
        public int CNT_Beauty => Data[0x25];
        public int CNT_Cute => Data[0x26];
        public int CNT_Smart => Data[0x27];
        public int CNT_Tough => Data[0x28];
        public int CNT_Sheen => Data[0x29];
        public byte Markings => Data[0x2A];
        public bool Circle => (Markings & (1 << 0)) == 1 << 0;
        public bool Triangle => (Markings & (1 << 1)) == 1 << 1;
        public bool Square => (Markings & (1 << 2)) == 1 << 2;
        public bool Heart => (Markings & (1 << 3)) == 1 << 3;
        public bool Star => (Markings & (1 << 4)) == 1 << 4;
        public bool Diamond => (Markings & (1 << 5)) == 1 << 5;
        private byte PKRS => Data[0x2B];
        public int PKRS_Days => PKRS & 0xF;
        public int PKRS_Strain => PKRS >> 4;
        private byte ST1 => Data[0x2C];
        public bool Unused0 => (ST1 & (1 << 0)) == 1 << 0;
        public bool Unused1 => (ST1 & (1 << 1)) == 1 << 1;
        public bool ST1_SPA => (ST1 & (1 << 2)) == 1 << 2;
        public bool ST1_HP => (ST1 & (1 << 3)) == 1 << 3;
        public bool ST1_ATK => (ST1 & (1 << 4)) == 1 << 4;
        public bool ST1_SPD => (ST1 & (1 << 5)) == 1 << 5;
        public bool ST1_SPE => (ST1 & (1 << 6)) == 1 << 6;
        public bool ST1_DEF => (ST1 & (1 << 7)) == 1 << 7;
        private byte ST2 => Data[0x2D];
        public bool ST2_SPA => (ST2 & (1 << 0)) == 1 << 0;
        public bool ST2_HP => (ST2 & (1 << 1)) == 1 << 1;
        public bool ST2_ATK => (ST2 & (1 << 2)) == 1 << 2;
        public bool ST2_SPD => (ST2 & (1 << 3)) == 1 << 3;
        public bool ST2_SPE => (ST2 & (1 << 4)) == 1 << 4;
        public bool ST2_DEF => (ST2 & (1 << 5)) == 1 << 5;
        public bool ST3_SPA => (ST2 & (1 << 6)) == 1 << 6;
        public bool ST3_HP => (ST2 & (1 << 7)) == 1 << 7;
        private byte ST3 => Data[0x2E];
        public bool ST3_ATK => (ST3 & (1 << 0)) == 1 << 0;
        public bool ST3_SPD => (ST3 & (1 << 1)) == 1 << 1;
        public bool ST3_SPE => (ST3 & (1 << 2)) == 1 << 2;
        public bool ST3_DEF => (ST3 & (1 << 3)) == 1 << 3;
        public bool ST4_1 => (ST3 & (1 << 4)) == 1 << 4;
        public bool ST5_1 => (ST3 & (1 << 5)) == 1 << 5;
        public bool ST5_2 => (ST3 & (1 << 6)) == 1 << 6;
        public bool ST5_3 => (ST3 & (1 << 7)) == 1 << 7;
        private byte ST4 => Data[0x2F];
        public bool ST5_4 => (ST4 & (1 << 0)) == 1 << 0;
        public bool ST6_1 => (ST4 & (1 << 1)) == 1 << 1;
        public bool ST6_2 => (ST4 & (1 << 2)) == 1 << 2;
        public bool ST6_3 => (ST4 & (1 << 3)) == 1 << 3;
        public bool ST7_1 => (ST4 & (1 << 4)) == 1 << 4;
        public bool ST7_2 => (ST4 & (1 << 5)) == 1 << 5;
        public bool ST7_3 => (ST4 & (1 << 6)) == 1 << 6;
        public bool ST8_1 => (ST4 & (1 << 7)) == 1 << 7;
        private byte RIB0 => Data[0x30];
        public bool RIB0_0 => (RIB0 & (1 << 0)) == 1 << 0;
        public bool RIB0_1 => (RIB0 & (1 << 1)) == 1 << 1;
        public bool RIB0_2 => (RIB0 & (1 << 2)) == 1 << 2;
        public bool RIB0_3 => (RIB0 & (1 << 3)) == 1 << 3;
        public bool RIB0_4 => (RIB0 & (1 << 4)) == 1 << 4;
        public bool RIB0_5 => (RIB0 & (1 << 5)) == 1 << 5;
        public bool RIB0_6 => (RIB0 & (1 << 6)) == 1 << 6;
        public bool RIB0_7 => (RIB0 & (1 << 7)) == 1 << 7;
        private byte RIB1 => Data[0x31];
        public bool RIB1_0 => (RIB1 & (1 << 0)) == 1 << 0;
        public bool RIB1_1 => (RIB1 & (1 << 1)) == 1 << 1;
        public bool RIB1_2 => (RIB1 & (1 << 2)) == 1 << 2;
        public bool RIB1_3 => (RIB1 & (1 << 3)) == 1 << 3;
        public bool RIB1_4 => (RIB1 & (1 << 4)) == 1 << 4;
        public bool RIB1_5 => (RIB1 & (1 << 5)) == 1 << 5;
        public bool RIB1_6 => (RIB1 & (1 << 6)) == 1 << 6;
        public bool RIB1_7 => (RIB1 & (1 << 7)) == 1 << 7;
        private byte RIB2 => Data[0x32];
        public bool RIB2_0 => (RIB2 & (1 << 0)) == 1 << 0;
        public bool RIB2_1 => (RIB2 & (1 << 1)) == 1 << 1;
        public bool RIB2_2 => (RIB2 & (1 << 2)) == 1 << 2;
        public bool RIB2_3 => (RIB2 & (1 << 3)) == 1 << 3;
        public bool RIB2_4 => (RIB2 & (1 << 4)) == 1 << 4;
        public bool RIB2_5 => (RIB2 & (1 << 5)) == 1 << 5;
        public bool RIB2_6 => (RIB2 & (1 << 6)) == 1 << 6;
        public bool RIB2_7 => (RIB2 & (1 << 7)) == 1 << 7;
        private byte RIB3 => Data[0x33];
        public bool RIB3_0 => (RIB3 & (1 << 0)) == 1 << 0;
        public bool RIB3_1 => (RIB3 & (1 << 1)) == 1 << 1;
        public bool RIB3_2 => (RIB3 & (1 << 2)) == 1 << 2;
        public bool RIB3_3 => (RIB3 & (1 << 3)) == 1 << 3;
        public bool RIB3_4 => (RIB3 & (1 << 4)) == 1 << 4;
        public bool RIB3_5 => (RIB3 & (1 << 5)) == 1 << 5;
        public bool RIB3_6 => (RIB3 & (1 << 6)) == 1 << 6;
        public bool RIB3_7 => (RIB3 & (1 << 7)) == 1 << 7;
        private byte RIB4 => Data[0x34];
        public bool RIB4_0 => (RIB4 & (1 << 0)) == 1 << 0;
        public bool RIB4_1 => (RIB4 & (1 << 1)) == 1 << 1;
        public bool RIB4_2 => (RIB4 & (1 << 2)) == 1 << 2;
        public bool RIB4_3 => (RIB4 & (1 << 3)) == 1 << 3;
        public bool RIB4_4 => (RIB4 & (1 << 4)) == 1 << 4;
        public bool RIB4_5 => (RIB4 & (1 << 5)) == 1 << 5;
        public bool RIB4_6 => (RIB4 & (1 << 6)) == 1 << 6;
        public bool RIB4_7 => (RIB4 & (1 << 7)) == 1 << 7;
        private byte RIB5 => Data[0x35];
        public bool RIB5_0 => (RIB5 & (1 << 0)) == 1 << 0;
        public bool RIB5_1 => (RIB5 & (1 << 1)) == 1 << 1;
        public bool RIB5_2 => (RIB5 & (1 << 2)) == 1 << 2;
        public bool RIB5_3 => (RIB5 & (1 << 3)) == 1 << 3;
        public bool RIB5_4 => (RIB5 & (1 << 4)) == 1 << 4;
        public bool RIB5_5 => (RIB5 & (1 << 5)) == 1 << 5;
        public bool RIB5_6 => (RIB5 & (1 << 6)) == 1 << 6;
        public bool RIB5_7 => (RIB5 & (1 << 7)) == 1 << 7;
        public byte _0x36 => Data[0x36];
        public byte _0x37 => Data[0x37];
        public int Memory_ContestCount => Data[0x38];
        public int Memory_BattleCount => Data[0x39];
        private byte DistByte => Data[0x3A];
        public bool Dist1 => (DistByte & (1 << 0)) == 1 << 0;
        public bool Dist2 => (DistByte & (1 << 1)) == 1 << 1;
        public bool Dist3 => (DistByte & (1 << 2)) == 1 << 2;
        public bool Dist4 => (DistByte & (1 << 3)) == 1 << 3;
        public bool Dist5 => (DistByte & (1 << 4)) == 1 << 4;
        public bool Dist6 => (DistByte & (1 << 5)) == 1 << 5;
        public bool Dist7 => (DistByte & (1 << 6)) == 1 << 6;
        public bool Dist8 => (DistByte & (1 << 7)) == 1 << 7;
        public byte _0x3B => Data[0x3B];
        public byte _0x3C => Data[0x3C];
        public byte _0x3D => Data[0x3D];
        public byte _0x3E => Data[0x3E];
        public byte _0x3F => Data[0x3F];

        #endregion
        #region Block B
        public string Nickname => TrimFromZero(Encoding.Unicode.GetString(Data, 0x40, 24))
            .Replace("\uE08F", "\u2640") // nidoran
            .Replace("\uE08E", "\u2642") // nidoran
            .Replace("\u2019", "\u0027");
        public int Move1 { get { return BitConverter.ToUInt16(Data, 0x5A); } private set { BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x5A); } }
        public int Move2 { get { return BitConverter.ToUInt16(Data, 0x5C); } private set { BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x5C); } }
        public int Move3 { get { return BitConverter.ToUInt16(Data, 0x5E); } private set { BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x5E); } }
        public int Move4 { get { return BitConverter.ToUInt16(Data, 0x60); } private set { BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x60); } }
        public int Move1_PP { get { return Data[0x62]; } private set { Data[0x62] = (byte)value; } }
        public int Move2_PP { get { return Data[0x63]; } private set { Data[0x63] = (byte)value; } }
        public int Move3_PP { get { return Data[0x64]; } private set { Data[0x64] = (byte)value; } }
        public int Move4_PP { get { return Data[0x65]; } private set { Data[0x65] = (byte)value; } }
        public int Move1_PPUps { get { return Data[0x66]; } private set { Data[0x66] = (byte)value; } }
        public int Move2_PPUps { get { return Data[0x67]; } private set { Data[0x67] = (byte)value; } }
        public int Move3_PPUps { get { return Data[0x68]; } private set { Data[0x68] = (byte)value; } }
        public int Move4_PPUps { get { return Data[0x69]; } private set { Data[0x69] = (byte)value; } }
        public int RelearnMove1 { get { return BitConverter.ToUInt16(Data, 0x6A); } private set { BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x6A); } }
        public int RelearnMove2 { get { return BitConverter.ToUInt16(Data, 0x6C); } private set { BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x6C); } }
        public int RelearnMove3 { get { return BitConverter.ToUInt16(Data, 0x6E); } private set { BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x6E); } }
        public int RelearnMove4 { get { return BitConverter.ToUInt16(Data, 0x70); } private set { BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x70); } }
        public bool SecretSuperTraining => Data[0x72] == 1;
        public byte _0x73 => Data[0x73];
        private uint IV32 { get { return BitConverter.ToUInt32(Data, 0x74); } set { BitConverter.GetBytes(value).CopyTo(Data, 0x74); } }
        public int IV_HP { get { return (int)(IV32 >> 00) & 0x1F; } private set { IV32 = (uint)((IV32 & ~(0x1F << 00)) | (uint)((value > 31 ? 31 : value) << 00)); } }
        public int IV_ATK { get { return (int)(IV32 >> 05) & 0x1F; } private set { IV32 = (uint)((IV32 & ~(0x1F << 05)) | (uint)((value > 31 ? 31 : value) << 05)); } }
        public int IV_DEF { get { return (int)(IV32 >> 10) & 0x1F; } private set { IV32 = (uint)((IV32 & ~(0x1F << 10)) | (uint)((value > 31 ? 31 : value) << 10)); } }
        public int IV_SPE { get { return (int)(IV32 >> 15) & 0x1F; } private set { IV32 = (uint)((IV32 & ~(0x1F << 15)) | (uint)((value > 31 ? 31 : value) << 15)); } }
        public int IV_SPA { get { return (int)(IV32 >> 20) & 0x1F; } private set { IV32 = (uint)((IV32 & ~(0x1F << 20)) | (uint)((value > 31 ? 31 : value) << 20)); } }
        public int IV_SPD { get { return (int)(IV32 >> 25) & 0x1F; } private set { IV32 = (uint)((IV32 & ~(0x1F << 25)) | (uint)((value > 31 ? 31 : value) << 25)); } }
        public bool IsEgg => ((IV32 >> 30) & 1) == 1;
        public bool IsNicknamed => ((IV32 >> 31) & 1) == 1;

        #endregion
        #region Block C
        public string HT_Name
        {
            get
            {
                return TrimFromZero(Encoding.Unicode.GetString(Data, 0x78, 24))
                    .Replace("\uE08F", "\u2640") // nidoran
                    .Replace("\uE08E", "\u2642") // nidoran
                    .Replace("\u2019", "\u0027"); // farfetch'd
            }
            private set
            {
                if (value.Length > 12)
                    value = value.Substring(0, 12); // Hard cap
                var tempNick = value // Replace Special Characters and add Terminator
                    .Replace("\u2640", "\uE08F") // nidoran
                    .Replace("\u2642", "\uE08E") // nidoran
                    .Replace("\u0027", "\u2019") // farfetch'd
                    .PadRight(value.Length + 1, '\0'); // Null Terminator
                Encoding.Unicode.GetBytes(tempNick).CopyTo(Data, 0x78);
            }
        }
        public int HT_Gender => Data[0x92];
        public int CurrentHandler => Data[0x93];
        public int Geo1_Region { get { return Data[0x94]; } private set { Data[0x94] = (byte)value; } }
        public int Geo1_Country { get { return Data[0x95]; } private set { Data[0x95] = (byte)value; } }
        public int Geo2_Region { get { return Data[0x96]; } private set { Data[0x96] = (byte)value; } }
        public int Geo2_Country { get { return Data[0x97]; } private set { Data[0x97] = (byte)value; } }
        public int Geo3_Region { get { return Data[0x98]; } private set { Data[0x98] = (byte)value; } }
        public int Geo3_Country { get { return Data[0x99]; } private set { Data[0x99] = (byte)value; } }
        public int Geo4_Region { get { return Data[0x9A]; } private set { Data[0x9A] = (byte)value; } }
        public int Geo4_Country { get { return Data[0x9B]; } private set { Data[0x9B] = (byte)value; } }
        public int Geo5_Region { get { return Data[0x9C]; } private set { Data[0x9C] = (byte)value; } }
        public int Geo5_Country { get { return Data[0x9D]; } private set { Data[0x9D] = (byte)value; } }
        public byte _0x9E => Data[0x9E];
        public byte _0x9F => Data[0x9F];
        public byte _0xA0 => Data[0xA0];
        public byte _0xA1 => Data[0xA1];
        public int HT_Friendship { get { return Data[0xA2]; } private set { Data[0xA2] = (byte)value; } }
        public int HT_Affection { get { return Data[0xA3]; } private set { Data[0xA3] = (byte)value; } }
        public int HT_Intensity { get { return Data[0xA4]; } private set { Data[0xA4] = (byte)value; } }
        public int HT_Memory { get { return Data[0xA5]; } private set { Data[0xA5] = (byte)value; } }
        public int HT_Feeling { get { return Data[0xA6]; } private set { Data[0xA6] = (byte)value; } }
        public byte _0xA7 => Data[0xA7];
        public int HT_TextVar { get { return BitConverter.ToUInt16(Data, 0xA8); } private set { BitConverter.GetBytes((ushort)value).CopyTo(Data, 0xA8); } }
        public byte _0xAA => Data[0xAA];
        public byte _0xAB => Data[0xAB];
        public byte _0xAC => Data[0xAC];
        public byte _0xAD => Data[0xAD];
        public byte Fullness => Data[0xAE];
        public byte Enjoyment => Data[0xAF];

        #endregion
        #region Block D
        public string OT_Name
        {
            get
            {
                return TrimFromZero(Encoding.Unicode.GetString(Data, 0xB0, 24))
                    .Replace("\uE08F", "\u2640") // Nidoran ♂
                    .Replace("\uE08E", "\u2642") // Nidoran ♀
                    .Replace("\u2019", "\u0027"); // farfetch'd
            }
            private set
            {
                if (value.Length > 12)
                    value = value.Substring(0, 12); // Hard cap
                string TempNick = value // Replace Special Characters and add Terminator
                .Replace("\u2640", "\uE08F") // Nidoran ♂
                .Replace("\u2642", "\uE08E") // Nidoran ♀
                .Replace("\u0027", "\u2019") // Farfetch'd
                .PadRight(value.Length + 1, '\0'); // Null Terminator
                Encoding.Unicode.GetBytes(TempNick).CopyTo(Data, 0xB0);
            }
        }
        public int OT_Friendship => Data[0xCA];
        public int OT_Affection { get { return Data[0xCB]; } private set { Data[0xCB] = (byte)value; } }
        public int OT_Intensity { get { return Data[0xCC]; } private set { Data[0xCC] = (byte)value; } }
        public int OT_Memory { get { return Data[0xCD]; } private set { Data[0xCD] = (byte)value; } }
        public int OT_TextVar { get { return BitConverter.ToUInt16(Data, 0xCE); } private set { BitConverter.GetBytes((ushort)value).CopyTo(Data, 0xCE); } }
        public int OT_Feeling { get { return Data[0xD0]; } private set { Data[0xD0] = (byte)value; } }
        public int Egg_Year => Data[0xD1];
        public int Egg_Month => Data[0xD2];
        public int Egg_Day => Data[0xD3];
        public int Met_Year => Data[0xD4];
        public int Met_Month => Data[0xD5];
        public int Met_Day => Data[0xD6];
        public byte _0xD7 => Data[0xD7];
        public int Egg_Location => BitConverter.ToUInt16(Data, 0xD8);
        public int Met_Location => BitConverter.ToUInt16(Data, 0xDA);
        public int Ball => Data[0xDC];
        public int Met_Level => Data[0xDD] & ~0x80;
        public int OT_Gender => Data[0xDD] >> 7;
        public int EncounterType => Data[0xDE];
        public int Version => Data[0xDF];
        public int Country => Data[0xE0];
        public int Region => Data[0xE1];
        public int ConsoleRegion => Data[0xE2];
        public int Language => Data[0xE3];

        #endregion
        #region Battle Stats
        public int Stat_Level => Data[0xEC];
        public int Stat_HPCurrent => BitConverter.ToUInt16(Data, 0xF0);
        public int Stat_HPMax => BitConverter.ToUInt16(Data, 0xF2);
        public int Stat_ATK => BitConverter.ToUInt16(Data, 0xF4);
        public int Stat_DEF => BitConverter.ToUInt16(Data, 0xF6);
        public int Stat_SPE => BitConverter.ToUInt16(Data, 0xF8);
        public int Stat_SPA => BitConverter.ToUInt16(Data, 0xFA);
        public int Stat_SPD => BitConverter.ToUInt16(Data, 0xFC);

        #endregion

        // Simple Generated Attributes
        public int CurrentFriendship => CurrentHandler == 0 ? OT_Friendship : HT_Friendship;
        public int OppositeFriendship => CurrentHandler == 1 ? OT_Friendship : HT_Friendship;

        public int[] IVs => new[] { IV_HP, IV_ATK, IV_DEF, IV_SPE, IV_SPA, IV_SPD };
        public int[] EVs => new[] { EV_HP, EV_ATK, EV_DEF, EV_SPE, EV_SPA, EV_SPD };
        public int PSV => (int)((PID >> 16 ^ PID & 0xFFFF) >> 4);
        public int TSV => (TID ^ SID) >> 4;
        public bool IsShiny => TSV == PSV;
        public bool PKRS_Infected => PKRS_Strain > 0;
        public bool PKRS_Cured => PKRS_Days == 0 && PKRS_Strain > 0;
        public bool IsUntraded => string.IsNullOrEmpty(HT_Name);
        public bool IsUntradedEvent6 => Geo1_Country == 0 && Geo1_Region == 0 && Met_Location / 10000 == 4 && Gen6;
        public bool Gen6 => Version >= 24 && Version <= 29;
        public bool Gen5 => Version >= 20 && Version <= 23;
        public bool Gen4 => Version >= 10 && Version < 12 || Version >= 7 && Version <= 8;
        public bool Gen3 => Version >= 1 && Version <= 5 || Version == 15;
        public bool GenU => !(Gen6 || Gen5 || Gen4 || Gen3);

        public int[] Moves => new[] { Move1, Move2, Move3, Move4 };

        // Complex Generated Attributes
        public int HPType => (15 * ((IV_HP & 1) + 2 * (IV_ATK & 1) + 4 * (IV_DEF & 1) + 8 * (IV_SPE & 1) + 16 * (IV_SPA & 1) + 32 * (IV_SPD & 1))) / 63;

        public int Characteristic
        {
            get
            {
                // Characteristic with EC%6
                var pm6 = (int) (EncryptionConstant % 6); // EC MOD 6
                var maxIV = IVs.Max();
                var pm6stat = 0;

                for (var i = 0; i < 6; i++)
                {
                    pm6stat = (pm6 + i) % 6;
                    if (IVs[pm6stat] == maxIV)
                        break; // P%6 is this stat
                }
                return pm6stat * 5 + maxIV % 5;
            }
        }
        public int PotentialRating
        {
            get
            {
                var ivTotal = IVs.Sum();
                if (ivTotal <= 90)
                    return 0;
                if (ivTotal <= 120)
                    return 1;
                return ivTotal <= 150 ? 2 : 3;
            }
        }

        // Methods
        public void RefreshChecksum() { Checksum = CalculateChecksum(); }
        private ushort CalculateChecksum()
        {
            ushort chk = 0;
            for (var i = 8; i < SIZE_STORED; i += 2) // Loop through the entire PK6
                chk += BitConverter.ToUInt16(Data, i);

            return chk;
        }

        // General User-error Fixes
        public void FixMoves()
        {
            if (Move4 != 0 && Move3 == 0)
            {
                Move3 = Move4;
                Move3_PP = Move4_PP;
                Move3_PPUps = Move4_PPUps;
                Move4 = Move4_PP = Move4_PPUps = 0;
            }
            if (Move3 != 0 && Move2 == 0)
            {
                Move2 = Move3;
                Move2_PP = Move3_PP;
                Move2_PPUps = Move3_PPUps;
                Move3 = Move3_PP = Move3_PPUps = 0;
            }
            if (Move2 != 0 && Move1 == 0)
            {
                Move1 = Move2;
                Move1_PP = Move2_PP;
                Move1_PPUps = Move2_PPUps;
                Move2 = Move2_PP = Move2_PPUps = 0;
            }
        }
        public void FixRelearn()
        {
            if (RelearnMove4 != 0 && RelearnMove3 == 0)
            {
                RelearnMove3 = RelearnMove4;
                RelearnMove4 = 0;
            }
            if (RelearnMove3 != 0 && RelearnMove2 == 0)
            {
                RelearnMove2 = RelearnMove3;
                RelearnMove3 = 0;
            }
            if (RelearnMove2 != 0 && RelearnMove1 == 0)
            {
                RelearnMove1 = RelearnMove2;
                RelearnMove2 = 0;
            }
        }
        public void FixMemories()
        {
            if (IsEgg) // No memories if is egg.
            {
                Geo1_Country = Geo2_Country = Geo3_Country = Geo4_Country = Geo5_Country =
                Geo1_Region = Geo2_Region = Geo3_Region = Geo4_Region = Geo5_Region =
                HT_Friendship = HT_Affection = HT_TextVar = HT_Memory = HT_Intensity = HT_Feeling =
                /* OT_Friendship = */ OT_Affection = OT_TextVar = OT_Memory = OT_Intensity = OT_Feeling = 0;

                // Clear Handler
                HT_Name = "".PadRight(11, '\0');
                return;
            }

            if (IsUntraded)
                HT_Friendship = HT_Affection = HT_TextVar = HT_Memory = HT_Intensity = HT_Feeling = 0;

            Geo1_Region = Geo1_Country > 0 ? Geo1_Region : 0;
            Geo2_Region = Geo2_Country > 0 ? Geo2_Region : 0;
            Geo3_Region = Geo3_Country > 0 ? Geo3_Region : 0;
            Geo4_Region = Geo4_Country > 0 ? Geo4_Region : 0;
            Geo5_Region = Geo5_Country > 0 ? Geo5_Region : 0;

            if (Geo5_Country != 0 && Geo4_Country == 0)
            {
                Geo4_Country = Geo5_Country;
                Geo4_Region = Geo5_Region;
                Geo5_Country = Geo5_Region = 0;
            }
            if (Geo4_Country != 0 && Geo3_Country == 0)
            {
                Geo3_Country = Geo4_Country;
                Geo3_Region = Geo4_Region;
                Geo4_Country = Geo4_Region = 0;
            }
            if (Geo3_Country != 0 && Geo2_Country == 0)
            {
                Geo2_Country = Geo3_Country;
                Geo2_Region = Geo3_Region;
                Geo3_Country = Geo3_Region = 0;
            }
            if (Geo2_Country != 0 && Geo1_Country == 0)
            {
                Geo1_Country = Geo2_Country;
                Geo1_Region = Geo2_Region;
                Geo2_Country = Geo2_Region = 0;
            }
            if (Geo1_Country == 0 && !IsUntraded && !IsUntradedEvent6)
            {
                // Traded Non-Eggs/Events need to have a current location.
                Geo1_Country = Country;
                Geo1_Region = Region;
            }
        }

        // Util
        private static string TrimFromZero(string input)
        {
            var index = input.IndexOf('\0');
            return index < 0 ? input : input.Substring(0, index);
        }
    }
}