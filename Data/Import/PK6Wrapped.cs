using System.Collections.Generic;
using System.Linq;

using PKHeX;

using PokeD.Core.Data.PokeD.Monster;
using PokeD.Core.Data.PokeD.Monster.Data;

namespace PokeD.Core.Data.Import
{
    public enum EncounterTypes
    {
        Land = 0,
        Cave = 1,
        Water = 2,
        RockSmash = 3,
        OldRod = 4,
        GoodRod = 5,
        SuperRod = 6,
        HeadbuttLow = 7,
        HeadbuttHigh = 8,
        LandMorning = 9,
        LandDay = 10,
        LandNight = 11,
        BugContest = 12,
    }
    public static class MetLocationTypes
    {
        public static readonly Dictionary<int, string> MetLocation = new Dictionary<int, string>()
            {
                {13, "Avance Trail"},
                {14, "Santalune Forest"},
                {16, "Route 3"},
                {17, "Ouvert Way"},
                {18, "Santalune City"},
                {20, "Route 4"},
                {21, "Parterre Way"},
                {22, "Lumiose City"},
                {24, "Prism Tower"},
                {26, "Lysandre Labs"},
                {28, "Route 5"},
                {29, "Versant Road"},
                {30, "Camphrier Town"},
                {32, "Shabboneau Castle"},
                {34, "Route 6"},
                {35, "Palais Lane"},
                {36, "Parfum Palace"},
                {38, "Route 7"},
                {39, "Rivière Walk"},
                {40, "Cyllage City"},
                {42, "Route 8"},
                {43, "Muraille Coast"},
                {44, "Ambrette Town"},
                {46, "Route 9"},
                {47, "Spikes Passage"},
                {48, "Battle Chateau"},
                {50, "Route 10"},
                {51, "Menhir Trail"},
                {52, "Geosenge Town"},
                {54, "Route 11"},
                {55, "Miroir Way"},
                {56, "Reflection Cave"},
                {58, "Shalour City"},
                {60, "Tower of Mastery"},
                {62, "Route 12"},
                {63, "Fourrage Road"},
                {64, "Coumarine City"},
                {66, "Route 13"},
                {67, "Lumiose Badlands"},
                {68, "Route 14"},
                {69, "Laverre Nature Trail"},
                {70, "Laverre City"},
                {72, "Poké Ball Factory"},
                {74, "Route 15"},
                {75, "Brun Way"},
                {76, "Dendemille Town"},
                {78, "Route 16"},
                {79, "Mélancolie Path"},
                {82, "Frost Cavern"},
                {84, "Route 17"},
                {85, "Mamoswine Road"},
                {86, "Anistar City"},
                {88, "Route 18"},
                {89, "Vallée Étroite Way"},
                {90, "Couriway Town"},
                {92, "Route 19"},
                {93, "Grande Vallée Way"},
                {94, "Snowbelle City"},
                {96, "Route 20"},
                {97, "Winding Woods"},
                {98, "Pokémon Village"},
                {100, "Route 21"},
                {101, "Dernière Way"},
                {102, "Route 22"},
                {103, "Détourner Way"},
                {104, "Victory Road (Kalos)"},
                {106, "Pokémon League (Kalos)"},
                {108, "Kiloude City"},
                {110, "Battle Maison"},
                {112, "Azure Bay"},
                {114, "Dendemille Gate"},
                {116, "Couriway Gate"},
                {118, "Ambrette Gate"},
                {120, "Lumiose Gate"},
                {122, "Shalour Gate"},
                {124, "Coumarine Gate"},
                {126, "Laverre Gate"},
                {128, "Anistar Gate"},
                {130, "Snowbelle Gate"},
                {132, "Glittering Cave"},
                {134, "Connecting Cave"},
                {135, "Zubat Roost"},
                {136, "Kalos Power Plant"},
                {138, "Team Flare Secret HQ"},
                {140, "Terminus Cave"},
                {142, "Lost Hotel"},
                {144, "Chamber of Emptiness"},
                {146, "Sea Spirit's Den"},
                {148, "Friend Safari"},
                {150, "Blazing Chamber"},
                {152, "Flood Chamber"},
                {154, "Ironworks Chamber"},
                {156, "Dragonmark Chamber"},
                {158, "Radiant Chamber"},
                {160, "Pokémon League Gate"},
                {162, "Lumiose Station"},
                {164, "Kiloude Station"},
                {166, "Ambrette Aquarium"},
                {168, "Unknown Dungeon"},
                {170, "Littleroot Town"},
                {172, "Oldale Town"},
                {174, "Dewford Town"},
                {176, "Lavaridge Town"},
                {178, "Fallarbor Town"},
                {180, "Verdanturf Town"},
                {182, "Pacifidlog Town"},
                {184, "Petalburg City"},
                {186, "Slateport City"},
                {188, "Mauville City"},
                {190, "Rustboro City"},
                {192, "Fortree City"},
                {194, "Lilycove City"},
                {196, "Mossdeep City"},
                {198, "Sootopolis City"},
                {200, "Ever Grande City"},
                {202, "Pokémon League (Hoenn)"},
                {204, "Route 101"},
                {206, "Route 102"},
                {208, "Route 103"},
                {210, "Route 104"},
                {212, "Route 105"},
                {214, "Route 106"},
                {216, "Route 107"},
                {218, "Route 108"},
                {220, "Route 109"},
                {222, "Route 110"},
                {224, "Route 111"},
                {226, "Route 112"},
                {228, "Route 113"},
                {230, "Route 114"},
                {232, "Route 115"},
                {234, "Route 116"},
                {236, "Route 117"},
                {238, "Route 118"},
                {240, "Route 119"},
                {242, "Route 120"},
                {244, "Route 121"},
                {246, "Route 122"},
                {248, "Route 123"},
                {250, "Route 124"},
                {252, "Route 125"},
                {254, "Route 126"},
                {256, "Route 127"},
                {258, "Route 128"},
                {260, "Route 129"},
                {262, "Route 130"},
                {264, "Route 131"},
                {266, "Route 132"},
                {268, "Route 133"},
                {270, "Route 134"},
                {272, "Meteor Falls"},
                {274, "Rusturf Tunnel"},
                {276, "Inside of Truck"},
                {278, "Desert Ruins"},
                {280, "Granite Cave"},
                {282, "Petalburg Woods"},
                {284, "Mt. Chimney"},
                {286, "Jagged Pass"},
                {288, "Fiery Path"},
                {290, "Mt. Pyre"},
                {292, "Team Aqua Hideout"},
                {294, "Seafloor Cavern"},
                {296, "Cave of Origin"},
                {298, "Victory Road (Hoenn)"},
                {300, "Shoal Cave"},
                {302, "New Mauville"},
                {304, "Sea Mauville"},
                {306, "Island Cave"},
                {308, "Ancient Tomb"},
                {310, "Sealed Chamber"},
                {312, "Scorched Slab"},
                {314, "Team Magma Hideout"},
                {316, "Sky Pillar"},
                {318, "Battle Resort"},
                {320, "Southern Island"},
                {322, "S.S. Tidal"},
                {324, "Safari Zone"},
                {326, "Mirage Forest"},
                {328, "Mirage Cave"},
                {330, "Mirage Island"},
                {332, "Mirage Mountain"},
                {334, "Trackless Forest"},
                {336, "Pathless Plain"},
                {338, "Nameless Cavern"},
                {340, "Fabled Cave"},
                {342, "Gnarled Den"},
                {344, "Crescent Isle"},
                {346, "Secret Islet"},
                {348, "Soaring in the sky"},
                {350, "Secret Shore"},
                {352, "Secret Meadow"},
                {354, "Secret Base"},
                {30001, "a Link Trade"},
                {30002, "a Link Trade*"},
                {30003, "the Kanto region"},
                {30004, "the Johto region"},
                {30005, "the Hoenn region"},
                {30006, "the Sinnoh region"},
                {30007, "a distant land"},
                {30008, "NONE"},
                {30009, "the Unova region"},
                {30010, "the Kalos region"},
                {30011, "Pokémon Link"},
                {40001, "a lovely place"},
                {40002, "a faraway place"},
                {40003, "a Pokémon movie"},
                {40004, "Pokémon Movie 13"},
                {40005, "Pokémon Movie 14"},
                {40006, "Pokémon Movie 15"},
                {40007, "Pokémon Movie 16"},
                {40008, "Pokémon Movie 17"},
                {40009, "Pokémon Movie 18"},
                {40010, "a Pokémon Center"},
                {40011, "the Pokémon cartoon"},
                {40012, "PC Tokyo"},
                {40013, "PC Osaka"},
                {40014, "PC Fukuoka"},
                {40015, "PC Nagoya"},
                {40016, "PC Sapporo"},
                {40017, "PC Yokohama"},
                {40018, "PC Tohoku"},
                {40019, "PC Tokyo Bay"},
                {40020, "a Pokémon Store"},
                {40021, "a WCS"},
                {40022, "WCS 2013"},
                {40023, "WCS 2014"},
                {40024, "WCS 2015"},
                {40025, "WCS 2016"},
                {40026, "WCS 2017"},
                {40027, "WCS 2018"},
                {40028, "Worlds"},
                {40029, "Worlds 2013"},
                {40030, "Worlds 2014"},
                {40031, "Worlds 2015"},
                {40032, "Worlds 2016"},
                {40033, "Worlds 2017"},
                {40034, "Worlds 2018"},
                {40035, "a VGE"},
                {40036, "VGE 2013"},
                {40037, "VGE 2014"},
                {40038, "VGE 2015"},
                {40039, "VGE 2016"},
                {40040, "VGE 2017"},
                {40041, "VGE 2018"},
                {40042, "a Pokémon event"},
                {40043, "a Battle Competition"},
                {40044, "a game event"},
                {40045, "the Pokémon Fan Club"},
                {40046, "a Pokémon TV program"},
                {40047, "a concert"},
                {40048, "an online Present"},
                {40049, "the PGL"},
                {40050, "Pokémon Event 13"},
                {40051, "Pokémon Event 14"},
                {40052, "Pokémon Event 15"},
                {40053, "Pokémon Event 16"},
                {40054, "Pokémon Event 17"},
                {40055, "Pokémon Event 18"},
                {40056, "Pokémon Festa"},
                {40057, "Pokémon Festa 13"},
                {40058, "Pokémon Festa 14"},
                {40059, "Pokémon Festa 15"},
                {40060, "Pokémon Festa 16"},
                {40061, "Pokémon Festa 17"},
                {40062, "Pokémon Festa 18"},
                {40063, "POKÉPARK"},
                {40064, "POKÉPARK"},
                {40065, "POKÉPARK"},
                {40066, "POKÉPARK"},
                {40067, "POKÉPARK"},
                {40068, "POKÉPARK"},
                {40069, "POKÉPARK"},
                {40070, "an event site"},
                {40071, "GAME FREAK"},
                {40072, "a stadium"},
                {40073, "a VGC"},
                {40074, "the VGC 2013"},
                {40075, "the VGC 2014"},
                {40076, "the VGC 2015"},
                {40077, "the VGC 2016"},
                {40078, "the VGC 2017"},
                {40079, "the VGC 2018"},
                {60001, "a stranger"},
                {60002, "a Day-Care CoupleXY/Day Care helpersORAS"},
                {60003, "a treasure hunter"},
                {60004, "an old hot-springs visitor"},
            };
    }
    
    public class PK6Wrapped
    {
        private PK6 Data { get; }


        public PK6Wrapped(PK6 data) { Data = data; }


        public short Species => checked((short) Data.Species);

        public string Nickname => Data.Nickname;
        public uint PID => Data.PID;
        public ushort SID => checked((ushort) Data.SID);
        public short Ability => checked((short) Data.Ability);
        public byte Nature => checked((byte) Data.Nature);
        public bool IsEgg => Data.IsEgg;
        public bool IsNicknamed => Data.IsNicknamed;
        public byte Ball => checked((byte) Data.Ball);
        public byte CurrentFriendship => checked((byte) Data.CurrentFriendship);
        public short HPCurrent => checked((short) Data.Stat_HPCurrent);
        public byte HiddenPowerType => checked((byte) Data.HPType);

        public int EXP => checked((int) Data.EXP);

        //public short[] IVs => new[] { (short) Data.IV_HP, (short) Data.IV_ATK, (short) Data.IV_DEF, (short) Data.IV_SPE, (short) Data.IV_SPA, (short) Data.IV_SPD };
        //public short[] EVs => new[] { (short) Data.EV_HP, (short) Data.EV_ATK, (short) Data.EV_DEF, (short) Data.EV_SPE, (short) Data.EV_SPA, (short) Data.EV_SPD };
        public short[] IVs => Data.IVs.Select(iv => (short) iv).ToArray();
        public short[] EVs => Data.EVs.Select(ev => (short) ev).ToArray();

        public short HeldItem => checked((short) Data.HeldItem);

        //public int CNT_Cool => Data[0x24];
        //public int CNT_Beauty => Data[0x25];
        //public int CNT_Cute => Data[0x26];
        //public int CNT_Smart => Data[0x27];
        //public int CNT_Tough => Data[0x28];
        //public int CNT_Sheen => Data[0x29];
        //public byte Markings => Data[0x2A];
        //public bool Circle => (Markings & (1 << 0)) == 1 << 0;
        //public bool Triangle => (Markings & (1 << 1)) == 1 << 1;
        //public bool Square => (Markings & (1 << 2)) == 1 << 2;
        //public bool Heart => (Markings & (1 << 3)) == 1 << 3;
        //public bool Star => (Markings & (1 << 4)) == 1 << 4;
        //public bool Diamond => (Markings & (1 << 5)) == 1 << 5;


        public short Move1 => checked((short) Data.Move1);
        public short Move2 => checked((short) Data.Move2);
        public short Move3 => checked((short) Data.Move3);
        public short Move4 => checked((short) Data.Move4);
        public byte Move1_PPUps => checked((byte) Data.Move1_PPUps);
        public byte Move2_PPUps => checked((byte) Data.Move2_PPUps);
        public byte Move3_PPUps => checked((byte) Data.Move3_PPUps);
        public byte Move4_PPUps => checked((byte) Data.Move4_PPUps);


        public string OT_Name => Data.OT_Name;
        public ushort OT_ID => checked((ushort) Data.TID);
        public byte OT_Gender => checked((byte) Data.OT_Gender);
        public byte OT_Friendship => checked((byte) Data.OT_Friendship);
        public byte OT_Affection => checked((byte) Data.OT_Affection);

        public short Egg_Year => checked((short) Data.Egg_Year);
        public byte Egg_Month => checked((byte) Data.Egg_Month);
        public byte Egg_Day => checked((byte) Data.Egg_Day);
        public int Egg_Location => Data.Egg_Location;
        public short Met_Year => checked((short) Data.Met_Year);
        public byte Met_Month => checked((byte) Data.Met_Month);
        public byte Met_Day => checked((byte) Data.Met_Day);
        public int Met_Location => Data.Met_Location;
        public byte Met_Level => checked((byte) Data.Met_Level);

        //public int EncounterType => Data.EncounterType;
        //public int Version => Data.Version;
        //public int Country => Data.Country;
        //public int Region => Data.Region;
        //public int ConsoleRegion => Data.ConsoleRegion;
        //public int Language => Data.Language;


        public MonsterInstanceData ConvertToMonsterInstanceData()
        {
            Data.FixMoves();
            Data.FixMemories();
            Data.FixRelearn();
            Data.RefreshChecksum();

            var data = new MonsterInstanceData(Species, SID, PID, Nature)
            {
                Affection = OT_Affection,
                CatchInfo = new MonsterCatchInfo()
                {
                    Method = "converted from a Pokémon Game",// "converted from Pokémon Game",// EncounterType.ToString(),
                    Location = $"on {MetLocationTypes.MetLocation[Met_Location]}",//"at PokéD's Server",//Met_Location.ToString(),
                    TrainerName = OT_Name,
                    TrainerID = OT_ID,
                    PokeballID = Ball,
                    Nickname = IsNicknamed ? Nickname : string.Empty
                },
                CurrentHP = HPCurrent,
                EV = new MonsterStats(EVs[0], EVs[1], EVs[2], EVs[3], EVs[4], EVs[5]),
                EggSteps = IsEgg ? 0 : 0,
                Experience = EXP,
                Friendship = CurrentFriendship,
                HeldItem = HeldItem,
                IV = new MonsterStats(IVs[0], IVs[1], IVs[2], IVs[3], IVs[4], IVs[5]),
                Moves = new MonsterMoves(
                    new MonsterMove(Move1, Move1_PPUps),
                    new MonsterMove(Move2, Move2_PPUps),
                    new MonsterMove(Move3, Move3_PPUps),
                    new MonsterMove(Move4, Move4_PPUps))
            };

            // HT_Affection?
            //data.HiddenEV = new MonsterStats();

            return data;
        }
    }
}