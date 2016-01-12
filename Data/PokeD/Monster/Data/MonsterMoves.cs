namespace PokeD.Core.Data.PokeD.Monster.Data
{
    public class Move
    {
        public static Move Empty => new Move(0, 0);

        public int ID { get; }
        public int PPUPs { get; }


        public Move(int id, int ppUPs)
        {
            ID = id;
            PPUPs = ppUPs;
        }
    }

    public class MonsterMoves
    {
        public static MonsterMoves Empty => new MonsterMoves(Move.Empty, Move.Empty, Move.Empty, Move.Empty);

        public Move Move_0 { get; } = Move.Empty;
        public Move Move_1 { get; } = Move.Empty;
        public Move Move_2 { get; } = Move.Empty;
        public Move Move_3 { get; } = Move.Empty;

        public MonsterMoves(params Move[] moves)
        {
            if (moves.Length > 0)
                Move_0 = moves[0];

            if (moves.Length > 1)
                Move_1 = moves[1];

            if (moves.Length > 2)
                Move_2 = moves[2];

            if (moves.Length > 3)
                Move_3 = moves[3];
        }
        public MonsterMoves(Move move_0, Move move_1, Move move_2, Move move_3)
        {
            Move_0 = move_0;
            Move_1 = move_1;
            Move_2 = move_2;
            Move_3 = move_3;
        }
    }
}