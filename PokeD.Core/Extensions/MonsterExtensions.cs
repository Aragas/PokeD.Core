using System.Collections.Generic;
using System.Linq;
using System.Text;

using PokeD.Core.Data.P3D;
using PokeD.Core.Data.PokeD;

namespace PokeD.Core.Extensions
{
    public static class MonsterExtensions
    {
        public static DataItems ToDataItems(this Monster monster)
        {
#pragma warning disable IDE0028 // Simplify collection initialization
            var dict = new Dictionary<string, string>();
            dict.Add("Pokemon", $"[{monster.StaticData.ID}]");
            dict.Add("Experience", $"[{monster.Experience}]");
            dict.Add("Gender", $"[{((int) monster.Gender)}]");
            dict.Add("EggSteps", $"[{monster.EggSteps}]");
            dict.Add("Item", $"[{monster.HeldItem?.StaticData.ID ?? 0}]");
            dict.Add("ItemData", $"[]");
            dict.Add("NickName", $"[{monster.DisplayName}]");
            dict.Add("Level", $"[{monster.Level}]");
            dict.Add("OT", $"[{monster.CatchInfo.TrainerID}]");
            dict.Add("Ability", $"[{monster.Ability.StaticData.ID}]");
            dict.Add("Status", $"[]"); // TODO
            dict.Add("Nature", $"[{monster.Nature}]");
            dict.Add("CatchLocation", $"[{monster.CatchInfo.Location}]");
            dict.Add("CatchTrainer", $"[{monster.CatchInfo.TrainerName}]");
            dict.Add("CatchBall", $"[{monster.CatchInfo.PokeballID}]");
            dict.Add("CatchMethod", $"[{monster.CatchInfo.Method}]");
            dict.Add("Friendship", $"[{monster.Friendship}]");
            dict.Add("isShiny", $"[{(monster.IsShiny ? 1 : 0)}]");

            if (monster.Moves.Count > 0)
            {
                var pp = monster.Moves[0].StaticData.PP;
                var ppMax = (int) (monster.Moves[0].PPUps > 0 ? pp + pp * 0.2D * monster.Moves[0].PPUps : pp);
                dict.Add("Attack1", $"[{monster.Moves[0].StaticData.ID},{ppMax},{monster.Moves[0].PPCurrent}]");
            }
            else
                dict.Add("Attack1", "[]");
            if (monster.Moves.Count > 1)
            {
                var pp = monster.Moves[1].StaticData.PP;
                var ppMax = (int) (monster.Moves[1].PPUps > 0 ? pp + pp * 0.2D * monster.Moves[1].PPUps : pp);
                dict.Add("Attack2", $"[{monster.Moves[1].StaticData.ID},{ppMax},{monster.Moves[1].PPCurrent}]");
            }
            else
                dict.Add("Attack2", "[]");
            if (monster.Moves.Count > 2)
            {
                var pp = monster.Moves[2].StaticData.PP;
                var ppMax = (int) (monster.Moves[2].PPUps > 0 ? pp + pp * 0.2D * monster.Moves[2].PPUps : pp);
                dict.Add("Attack3", $"[{monster.Moves[2].StaticData.ID},{ppMax},{monster.Moves[2].PPCurrent}]");
            }
            else
                dict.Add("Attack3", "[]");
            if (monster.Moves.Count > 3)
            {
                var pp = monster.Moves[3].StaticData.PP;
                var ppMax =  (int) (monster.Moves[3].PPUps > 0 ? pp + pp * 0.2D * monster.Moves[3].PPUps : pp);
                dict.Add("Attack4", $"[{monster.Moves[3].StaticData.ID},{ppMax},{monster.Moves[3].PPCurrent}]");
            }
            else
                dict.Add("Attack4", "[]");

            dict.Add("HP", $"[{monster.CurrentHP}]");
            dict.Add("EVs", $"[{monster.EV.HP},{monster.EV.Attack},{monster.EV.Defense},{monster.EV.SpecialAttack},{monster.EV.SpecialDefense},{monster.EV.Speed}]");
            dict.Add("IVs", $"[{monster.IV.HP},{monster.IV.Attack},{monster.IV.Defense},{monster.IV.SpecialAttack},{monster.IV.SpecialDefense},{monster.IV.Speed}]");
            dict.Add("AdditionalData", $"[]");
            dict.Add("IDValue", $"[{GetP3DID(monster.PersonalityValue)}]");
#pragma warning restore IDE0028 // Simplify collection initialization

            return DictionaryToDataItems(dict);
        }
        private static string GetP3DID(uint personalityValue)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var result = "";
            var digits = Digits(personalityValue).ToList();
            for (var i = 0; i < 5; i += 2)
            {
                var number = int.Parse($"{digits[i]}{digits[i]}");
                if (number > chars.Length)
                    number = chars.Length - 1;
                result += chars[number];
            }

            return result;
        }
        private static IEnumerable<uint> Digits(this uint number)
        {
            do
            {
                yield return number % 10;
                number /= 10;
            } while (number > 0);
        }
        private static DataItems DictionaryToDataItems(Dictionary<string, string> dict)
        {
            var builder = new StringBuilder();

            foreach (var s in dict)
                builder.Append($"{{\"{s.Key}\"{s.Value}}}");

            return new DataItems(builder.ToString());
        }
    }
}