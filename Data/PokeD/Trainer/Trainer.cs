using Aragas.Network.Data;

using PokeD.Core.Data.PokeD.Monster.Interfaces;
using PokeD.Core.Data.PokeD.Trainer.Data;
using PokeD.Core.Data.PokeD.Trainer.Interfaces;

namespace PokeD.Core.Data.PokeD.Trainer
{
    public class TrainerStaticData
    {
        public string Id;
        public string Name;

    }
    public class TrainernInstanceData
    {
        public TrainerStaticData StaticData { get; }

        public string Name { get; }
        public short TrainerId { get; }
        public short SecretId { get; }

        public TrainerGender Gender { get; }

        public TrainernInstanceData(string name, TrainerGender gender)
        {
            Name = name;
            Gender = gender;
        }
        public TrainernInstanceData(string name)
        {
            Name = name;
        }

        public static TrainernInstanceData LoadData(int entityId)
        {
            return null;
        }
    }

    public class Trainer : IOpponentInfo, IOpponentServerInfo, IOpponentTeamInfo, IOpponentBattleInfo
    {
        public int EntityId { get; set; } = -1;
        public short TrainerSprite { get; }
        private TrainernInstanceData TrainernInstanceData { get; }

        public string Name
        {
            get { return TrainernInstanceData.Name; }
            set { throw new System.NotImplementedException(); }
        }

        public short TrainerId => TrainernInstanceData.TrainerId;
        public short SecretId => TrainernInstanceData.SecretId;

        public TrainerGender Gender => TrainernInstanceData.Gender;

        public IOpponentTeam MonsterTeam { get; set; }
        public IMonsterBattleInfo MainMonster => MonsterTeam.Monster_1;


        public string Location;
        public Vector3 Position;
        public byte Facing;


        public Trainer(string name, TrainerGender gender)
        {
            TrainernInstanceData = new TrainernInstanceData(name, gender);
        }
        public Trainer(string name)
        {
            TrainernInstanceData = new TrainernInstanceData(name);
        }
        private Trainer(int entityId)
        {
            EntityId = entityId;

            TrainernInstanceData = TrainernInstanceData.LoadData(EntityId);
        }
        public static Trainer Load(int entityId)
        {
            return new Trainer(entityId);
        }
    }
}
