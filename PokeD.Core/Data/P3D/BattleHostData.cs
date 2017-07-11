using System.Collections.Generic;

namespace PokeD.Core.Data.P3D
{
    public class BattleHostData
    {
        public static implicit operator string(BattleHostData battleData) => battleData._battleData;
        public static implicit operator BattleHostData(string battleData) => new BattleHostData(battleData);

        private readonly string _battleData;

        public IReadOnlyList<string> Queries => ParseHostData(_battleData);

        public BattleHostData(string battleData) => _battleData = battleData;

        
        private static IReadOnlyList<string> ParseHostData(string data)
        {
            var newQueries = new List<string>();
            var tempData = string.Empty;
            
            while (data.Length > 0)
            {
                if (data[0] == '|' && tempData[tempData.Length - 1] == '}')
                {
                    newQueries.Add(tempData);
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
                newQueries.Add(tempData);
                tempData = "";
            }

            return newQueries;
        }
    }
}