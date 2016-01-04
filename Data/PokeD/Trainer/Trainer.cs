using Aragas.Core.Data;

using PokeD.Core.Data.PokeD.Monster;

namespace PokeD.Core.Data.PokeD.Trainer
{
    public enum TrainerGender { Male, Female }

    public class TrainerStaticData
    {
        public string ID;
        public string Name;

    }
    public class TrainernInstanceData
    {
        public TrainerStaticData StaticData { get; }

        public string Name { get; }
        public short TrainerID { get; }
        public short SecretID { get; }

        public TrainerGender Gender { get; }

        public TrainernInstanceData(string name, TrainerGender gender)
        {
            Name = name;
            Gender = gender;
        }

        public static TrainernInstanceData LoadData(int entityID)
        {
            return null;
        }
    }


    public class Trainer : IOpponentInfo, IOpponentServerInfo, IOpponentTeamInfo, IOpponentBattleInfo
    {
        public VarInt EntityID { get; }
        public short TrainerSprite { get; }
        private TrainernInstanceData TrainernInstanceData { get; }

        public string Name => TrainernInstanceData.Name;
        public short TrainerID => TrainernInstanceData.TrainerID;
        public short SecretID => TrainernInstanceData.SecretID;

        public TrainerGender Gender => TrainernInstanceData.Gender;

        public IOpponentTeam MonsterTeam { get; set; }
        public IMonsterBattleInfo MainMonster => MonsterTeam.Monster_1;



        public Trainer(string name, TrainerGender gender)
        {
            TrainernInstanceData = new TrainernInstanceData(name, gender);
        }
        private Trainer(int entityID)
        {
            EntityID = entityID;

            TrainernInstanceData = TrainernInstanceData.LoadData(EntityID);
        }
        public static Trainer Load(int entityID)
        {
            return new Trainer(entityID);
        }
    }
}
