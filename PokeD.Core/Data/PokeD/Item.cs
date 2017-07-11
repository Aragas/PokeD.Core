using System.Collections.Generic;
using System.Linq;

using PokeD.BattleEngine.Item;
using PokeD.BattleEngine.Item.Data;
using PokeD.Core.Data.PokeApi;

namespace PokeD.Core.Data.PokeD
{
    public class ItemStaticData : IItemStaticData
    {
        public static Languages Language { get; set; } = Languages.English;
        private static bool GetLocalizedName(Localization name) => ((Languages) new ResourceUri(name.language).ID) == Language;


        public int ID { get; }
        public string Name { get; }

        public IList<IItemAttribute> Attributes { get; } = new List<IItemAttribute>();


        public ItemStaticData(int id)
        {
            var item = PokeApiV2.GetItemAsync(new ResourceUri($"api/v2/item/{id}/", true)).Result;
            var itemAttributes = PokeApiV2.GetItemAttributesAsync(item.attributes.Select(att => new ResourceUri(att)).ToArray()).Result;


            ID = id;
            Name = item.names.Find(GetLocalizedName).name;

            foreach (var itemAttribute in itemAttributes)
            {
                switch (itemAttribute.id)
                {
                    case 1:
                        Attributes.Add(new ItemAttributeCountable());
                        break;

                    case 2:
                        Attributes.Add(new ItemAttributeConsumable());
                        break;

                    case 3:
                        Attributes.Add(new ItemAttributeUsableOverworld());
                        break;

                    case 4:
                        Attributes.Add(new ItemAttributeUsableInBattle());
                        break;

                    case 5:
                        Attributes.Add(new ItemAttributeHoldable());
                        break;

                    case 6:
                        Attributes.Add(new ItemAttributeHoldablePassive());
                        break;

                    case 7:
                        Attributes.Add(new ItemAttributeHoldableActive());
                        break;

                    case 8:
                        Attributes.Add(new ItemAttributeUnderground());
                        break;
                }
            }
        }

        public override string ToString() => $"{Name}"; //$"{Name,-15}";
    }

    public class Item : BaseItemInstance
    {
        public Item(int id) : base(Cached<ItemStaticData>.Get(id)) { }

        public Item(ResourceUri uri) : base(Cached<ItemStaticData>.Get(uri.ID)) { }
    }
}
