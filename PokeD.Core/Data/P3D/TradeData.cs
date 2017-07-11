using PokeD.Core.Data.PokeD;

namespace PokeD.Core.Data.P3D
{
    public class TradeData
    {
        public static implicit operator string(TradeData tradeData) => tradeData._tradeData;
        public static implicit operator TradeData(string tradeData) => new TradeData(tradeData);

        private readonly string _tradeData;
        
        public Monster Monster => new Monster(new DataItems(_tradeData));

        public TradeData(string tradeData) => _tradeData = tradeData;
    }
}
