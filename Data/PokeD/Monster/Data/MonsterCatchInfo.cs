namespace PokeD.Core.Data.PokeD.Monster.Data
{
    public class MonsterCatchInfo
    {
        public static MonsterCatchInfo Empty => new MonsterCatchInfo();

        public string Full => $"{Method} {Location}";
        public string Method { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        public string TrainerName { get; set; } = string.Empty;
        public ushort TrainerId { get; set; }

        public byte PokeballId { get; set; }

        public string Nickname { get; set; } = string.Empty;
    }
}