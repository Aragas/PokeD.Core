namespace PokeD.Core.Data.PokeD.Monster.Data
{
    public class Move
    {
        public int ID { get; }
        public int Additional { get; }


        public Move(int id, int additional)
        {
            ID = id;
            Additional = additional;
        }
    }

    public class MonsterMoves
    {
        public Move Move_0 { get; }
        public Move Move_1 { get; }
        public Move Move_2 { get; }
        public Move Move_3 { get; }


        public MonsterMoves(Move move_0, Move move_1, Move move_2, Move move_3)
        {
            Move_0 = move_0;
            Move_1 = move_1;
            Move_2 = move_2;
            Move_3 = move_3;
        }
    }
}