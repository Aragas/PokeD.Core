using PokeD.Core.Data.PokeD;

namespace PokeD.Core.Data.P3D
{
    public class TradeData : P3DData
    {
        public static implicit operator TradeData(string tradeData) => new(tradeData);

        public Monster Monster => new(Data);

        public TradeData(string tradeData) : base(tradeData) { }
    }
}