namespace PokeD.Core.Data.PokeD.Monster.Data
{
    public class MonsterCatchInfo
    {
        public string Full => $"{Method} {Location}";
        public string Method { get; set; }
        public string Location { get; set; }

        public string TrainerName { get; set; }
        public short TrainerID { get; set; }

        public byte PokeballID { get; set; }

        public string Nickname { get; set; } = string.Empty;
    }
}