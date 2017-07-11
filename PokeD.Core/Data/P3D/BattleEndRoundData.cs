using System.Collections.Generic;

namespace PokeD.Core.Data.P3D
{
    public class BattleEndRoundData
    {
        public static implicit operator string(BattleEndRoundData battleData) => battleData._battleData;
        public static implicit operator BattleEndRoundData(string battleData) => new BattleEndRoundData(battleData);

        private readonly string _battleData;
        public IReadOnlyList<string> Queries => ParseEndRoundData(_battleData);

        public BattleEndRoundData(string battleData) { _battleData = battleData; }


        private static IReadOnlyList<string> ParseEndRoundData(string data)
        {
            var newQueries = new List<string>();
            var tempData = string.Empty;

            //Converts the single string received as data into a list of string 
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