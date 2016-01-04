using PokeD.Core.Data.PokeD.Trainer;

namespace PokeD.Core.Data.PokeD
{
    public interface IBattleInfo { }

    public class BattleInfo1x5 : IBattleInfo
    {
        //public IOpponentBattleInfo Opponent_0 { get; }
        public IOpponentBattleInfo Opponent_1 { get; }
        public IOpponentBattleInfo Opponent_2 { get; }
        public IOpponentBattleInfo Opponent_3 { get; }
        public IOpponentBattleInfo Opponent_4 { get; }
        public IOpponentBattleInfo Opponent_5 { get; }
    }
    public class BattleInfo3x3 : IBattleInfo
    {
        //public IOpponentBattleInfo  Opponent_0 { get; }
        public IOpponentBattleInfo Opponent_1 { get; }
        public IOpponentBattleInfo Opponent_2 { get; }
        public IOpponentBattleInfo Opponent_3 { get; }
        public IOpponentBattleInfo Opponent_4 { get; }
        public IOpponentBattleInfo Opponent_5 { get; }
    }
    public class BattleInfo2x2 : IBattleInfo
    {
        //public IOpponentBattleInfo Opponent_0 { get; }
        public IOpponentBattleInfo Opponent_1 { get; }
        public IOpponentBattleInfo Opponent_2 { get; }
        public IOpponentBattleInfo Opponent_3 { get; }
    }
    public class BattleInfo1x1 : IBattleInfo
    {
        //public IOpponentBattleInfo Opponent_0 { get; }
        public IOpponentBattleInfo Opponent_1 { get; }
    }
}