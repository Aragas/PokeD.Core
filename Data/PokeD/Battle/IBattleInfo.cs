using PokeD.Core.Data.PokeD.Trainer.Interfaces;

namespace PokeD.Core.Data.PokeD.Battle
{
    public interface IBattleInfo
    {
        int Count { get; }
    }

    public class BattleInfo1x5 : IBattleInfo
    {
        public int Count => 6;

        public IOpponentBattleInfo Opponent_0 { get; }
        public IOpponentBattleInfo Opponent_1 { get; }
        public IOpponentBattleInfo Opponent_2 { get; }
        public IOpponentBattleInfo Opponent_3 { get; }
        public IOpponentBattleInfo Opponent_4 { get; }
        public IOpponentBattleInfo Opponent_5 { get; }
    }
    public class BattleInfo3x3 : IBattleInfo
    {
        public int Count => 6;

        public IOpponentBattleInfo  Opponent_0 { get; }
        public IOpponentBattleInfo Opponent_1 { get; }
        public IOpponentBattleInfo Opponent_2 { get; }
        public IOpponentBattleInfo Opponent_3 { get; }
        public IOpponentBattleInfo Opponent_4 { get; }
        public IOpponentBattleInfo Opponent_5 { get; }
    }
    public class BattleInfo2x2 : IBattleInfo
    {
        public int Count => 4;

        public IOpponentBattleInfo Opponent_0 { get; }
        public IOpponentBattleInfo Opponent_1 { get; }
        public IOpponentBattleInfo Opponent_2 { get; }
        public IOpponentBattleInfo Opponent_3 { get; }
    }
    public class BattleInfo1x1 : IBattleInfo
    {
        public int Count => 2;

        public IOpponentBattleInfo Opponent_0 { get; }
        public IOpponentBattleInfo Opponent_1 { get; }
    }
}