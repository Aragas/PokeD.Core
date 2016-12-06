using System;

namespace PokeD.Core.Data.PokeD.Monster.Data
{
    public class MonsterMove
    {
        public static MonsterMove Empty => new MonsterMove(0, 0);

        public int Id { get; }
        public int PPUPs { get; }


        public MonsterMove(int id, int ppUPs)
        {
            Id = id;
            PPUPs = ppUPs;
        }
    }

    public class MonsterMoves
    {
        public static MonsterMoves Empty => new MonsterMoves();

        public MonsterMove Move_0 { get; } = MonsterMove.Empty;
        public MonsterMove Move_1 { get; } = MonsterMove.Empty;
        public MonsterMove Move_2 { get; } = MonsterMove.Empty;
        public MonsterMove Move_3 { get; } = MonsterMove.Empty;

        public MonsterMoves(params MonsterMove[] moves)
        {
            if (moves.Length > 0)
                Move_0 = moves[0];

            if (moves.Length > 1)
                Move_1 = moves[1];

            if (moves.Length > 2)
                Move_2 = moves[2];

            if (moves.Length > 3)
                Move_3 = moves[3];

            if (moves.Length > 4)
                throw new Exception();
        }
        public MonsterMoves(MonsterMove move_0, MonsterMove move_1, MonsterMove move_2, MonsterMove move_3)
        {
            Move_0 = move_0;
            Move_1 = move_1;
            Move_2 = move_2;
            Move_3 = move_3;
        }


        public bool Contains(MonsterMove move) => Move_0 == move || Move_1 == move || Move_2 == move || Move_3 == move;
        public bool Contains(short move) => Move_0.Id == move || Move_1.Id == move || Move_2.Id == move || Move_3.Id == move;
    }
}