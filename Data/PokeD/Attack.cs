using PokeD.BattleEngine.Attack;
using PokeD.BattleEngine.Attack.Enums;
using PokeD.BattleEngine.Type;
using PokeD.Core.Data.PokeApi;

namespace PokeD.Core.Data.PokeD
{
    public class AttackStaticData : IAttackStaticData
    {
        public static Languages Language { get; set; } = Languages.English;
        private static bool GetLocalizedName(Localization name) => ((Languages) new ResourceUri(name.language).ID) == Language;


        public short ID { get; }
        public string Name { get; }
        public ITypeStaticData Type { get; }

        public Target Target { get; }
        public DamageClass DamageClass { get; }

        public Condition AttackCondition { get; }

        public byte Power { get; }
        public byte Accuracy { get; }
        public byte Priority { get; }
        public byte PP { get; }

        public AttackStaticData(short id)
        {
            var move = PokeApiV2.GetMoveAsync(new ResourceUri($"api/v2/move/{id}/", true)).Result;

            ID = id;
            Name = move.names.Find(GetLocalizedName).name;
            //Type = new MonsterTypeStaticData((byte) new ResourceUri(move.type).ID);
            Type = Cached<MonsterTypeStaticData>.Get((byte) new ResourceUri(move.type).ID);

            Target = (Target) new ResourceUri(move.target).ID;

            DamageClass = (DamageClass) new ResourceUri(move.damage_class).ID;

            Power = (byte) (move.power ?? 0);
            Accuracy = (byte) (move.accuracy ?? 0);
            Priority = (byte) move.priority;

            PP = (byte) (move.pp ?? 0);
        }

        public override string ToString() => $"[Name: {Name,-20} PP: {PP,2} Pow: {Power,3} Acc: {Accuracy,3} Type: {Type,-10}]";
    }

    public class Attack : BaseAttackInstance
    {

        //public Attack(short id, IMonsterStaticData user) : base(new AttackStaticData(id)) { }
        //public Attack(short id, byte pp, byte ppUps, IMonsterStaticData user) : base(new AttackStaticData(id), pp, ppUps) { }
        public Attack(short id) : base(Cached<AttackStaticData>.Get(id)) { }
        public Attack(short id, byte pp, byte ppUps) : base(Cached<AttackStaticData>.Get(id), pp, ppUps) { }

        public Attack(AttackStaticData staticData) : base(staticData) { }
        public Attack(AttackStaticData staticData, byte pp, byte ppUps) : base(staticData, pp, ppUps) { }
    }
}
