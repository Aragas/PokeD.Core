using PokeD.BattleEngine.EggGroup;
using PokeD.Core.Data.PokeApi;

namespace PokeD.Core.Data.PokeD
{
    public class EggGroupStaticData : IEggGroupStaticData
    {
        public static Languages Language { get; set; } = Languages.English;
        private static bool GetLocalizedName(Localization name) => ((Languages) new ResourceUri(name.language).ID) == Language;

        public byte ID { get; }
        public string Name { get; }

        public EggGroupStaticData(byte id)
        {
            var eggGroup = PokeApiV2.GetEggGroupAsync(new ResourceUri($"api/v2/egg-group/{id}/", true)).Result;


            ID = id;
            Name = eggGroup.names.Find(GetLocalizedName).name;
        }

        public override string ToString() => $"{Name}";
    }
}
