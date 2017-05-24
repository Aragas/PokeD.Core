using PokeD.BattleEngine.Ability;
using PokeD.Core.Data.PokeApi;

namespace PokeD.Core.Data.PokeD
{
    public class AbilityStaticData : IAbilityStaticData
    {
        public static Languages Language { get; set; } = Languages.English;
        private static bool GetLocalizedName(Localization name) => ((Languages)new ResourceUri(name.language).ID) == Language;


        public short ID { get; }
        public string Name { get; }

        public AbilityStaticData(short id)
        {
            var ability = PokeApiV2.GetAbilityAsync(new ResourceUri($"api/v2/ability/{id}/", true)).Result;


            ID = id;
            Name = ability.names.Find(GetLocalizedName).name;
        }

        public override string ToString() => $"{Name}";
    }

    public class Ability : BaseAbility
    {
        //public Ability(short id, bool isHidden) : base(new AbilityStaticData(id), isHidden) { }

        public Ability(short id, bool isHidden) : base(Cached<AbilityStaticData>.Get(id), isHidden) { }

        public Ability(ResourceUri uri, bool isHidden) : base(Cached<AbilityStaticData>.Get((short) uri.ID), isHidden) { }
    }
}
