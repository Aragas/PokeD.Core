namespace PokeD.Core.Data.PokeD.Monster.Data
{
    public class MonsterHeldItem
    {
        public int ID { get; }
        public string Name { get; }
        public int Rarity { get; }

        public MonsterHeldItem(int id, string name, int rarity) { ID = id; Name = name; Rarity = rarity; }

        public override string ToString() => $"{Name}, ID: {ID}, Rarity: {Rarity}";
    }
}