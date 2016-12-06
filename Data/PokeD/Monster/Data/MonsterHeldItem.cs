namespace PokeD.Core.Data.PokeD.Monster.Data
{
    public class MonsterHeldItem
    {
        public int Id { get; }
        public string Name { get; }
        public int Rarity { get; }

        public MonsterHeldItem(int id, string name, int rarity) { Id = id; Name = name; Rarity = rarity; }

        public override string ToString() => $"{Name}, Id: {Id}, Rarity: {Rarity}";
    }
}