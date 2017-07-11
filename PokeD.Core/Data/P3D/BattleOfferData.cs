using System.Collections.Generic;
using PokeD.Core.Data.PokeD;

namespace PokeD.Core.Data.P3D
{
    public class BattleOfferData
    {
        public static implicit operator string(BattleOfferData battleData) => battleData._battleData;
        public static implicit operator BattleOfferData(string battleData) => new BattleOfferData(battleData);

        private readonly string _battleData;

        public IReadOnlyList<Monster> Monsters => ParseOfferData(_battleData);

        public BattleOfferData(string battleData) => _battleData = battleData;

        
        private static IReadOnlyList<Monster> ParseOfferData(string data)
        {
            var monsters = new List<Monster>();
            var tempData = string.Empty;
            
            while (data.Length > 0)
            {
                if (data[0] == '|' && tempData[tempData.Length - 1] == '}')
                {
                    monsters.Add(new Monster(new DataItems(tempData)));
                    tempData = "";
                }
                else
                {
                    tempData += data[0].ToString();
                }
                data = data.Remove(0, 1);
            }
            if (tempData.StartsWith("{") && tempData.EndsWith("}"))
            {
                monsters.Add(new Monster(new DataItems(tempData)));
                tempData = "";
            }

            return monsters;
        }
    }
}