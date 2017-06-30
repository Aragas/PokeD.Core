﻿using PokeD.BattleEngine.Trainer;
using PokeD.Core.Data.PokeApi;

namespace PokeD.Core.Data.PokeD
{
    public class TrainerStaticData : ITrainerStaticData
    {
        public int ID { get; }
        public string Name { get; }


        public TrainerStaticData(int id)
        {
            ID = id;
        }
    }

    public class Trainer : BaseTrainerInstance
    {
        public override int ID => TrainerID + SecretID * 65536;

        public short TrainerID { get; }
        public short SecretID { get; }

        //public Trainer(int id) : base(new TrainerStaticData(id)) { }

        public Trainer(int id) : base(Cached<TrainerStaticData>.Get(id)) { }

        public Trainer(ResourceUri uri) : base(Cached<TrainerStaticData>.Get(uri.ID)) { }
    }
}