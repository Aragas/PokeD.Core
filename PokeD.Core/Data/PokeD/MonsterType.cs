using PokeD.BattleEngine.Type;
using PokeD.BattleEngine.Type.Data;
using PokeD.Core.Data.PokeApi;

namespace PokeD.Core.Data.PokeD
{
    public class MonsterTypeStaticData : ITypeStaticData
    {
        public static Languages Language { get; set; } = Languages.English;
        private static bool GetLocalizedName(Localization name) => ((Languages) new ResourceUri(name.language).ID) == Language;


        public byte ID { get; }
        public string Name { get; }

        public DamageRelationRole DamageRelations { get; } = new DamageRelationRole();

        public MonsterTypeStaticData(byte id)
        {
            var type = PokeApiV2.GetTypeAsync(new ResourceUri($"api/v2/type/{id}/", true)).Result;

            ID = id;
            Name = type.names.Find(GetLocalizedName).name;

            foreach (var damageRelation in type.damage_relations.double_damage_to)
                DamageRelations.Attacker.Add(new TypeDamageRelationEffective((byte) new ResourceUri(damageRelation).ID));
            foreach (var damageRelation in type.damage_relations.half_damage_to)
                DamageRelations.Attacker.Add(new TypeDamageRelationNotEffective((byte) new ResourceUri(damageRelation).ID));
            foreach (var damageRelation in type.damage_relations.no_damage_to)
                DamageRelations.Attacker.Add(new TypeDamageRelationNone((byte) new ResourceUri(damageRelation).ID));

            foreach (var damageRelation in type.damage_relations.double_damage_from)
                DamageRelations.Defender.Add(new TypeDamageRelationEffective((byte) new ResourceUri(damageRelation).ID));
            foreach (var damageRelation in type.damage_relations.half_damage_from)
                DamageRelations.Defender.Add(new TypeDamageRelationNotEffective((byte) new ResourceUri(damageRelation).ID));
            foreach (var damageRelation in type.damage_relations.no_damage_from)
                DamageRelations.Defender.Add(new TypeDamageRelationNone((byte) new ResourceUri(damageRelation).ID));
        }

        public override string ToString() => $"{Name}";
    }
}
