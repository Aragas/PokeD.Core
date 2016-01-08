using Aragas.Core.Extensions;

namespace PokeD.Core.Data.PokeD.Structs
{
    public class MetaSwitch
    {
        public byte Meta { get; private set; }

        /// <summary>
        /// Index of used Monster.
        /// </summary>
        /// <remarks>Range 0-3, used 0-1.</remarks>
        public byte CurrentMonster { get { return Meta.BitsGet(0, 2); } set { Meta = Meta.BitsSet(value, 0, 2); } }

        /// <summary>
        /// Index of used Monster.
        /// </summary>
        /// <remarks>Range 0-7, used 0-5.</remarks>
        public byte SwitchMonster { get { return Meta.BitsGet(2, 5); } set { Meta = Meta.BitsSet(value, 2, 5); } }


        public MetaSwitch(byte currentMonster, byte switchMonster) { CurrentMonster = currentMonster; SwitchMonster = switchMonster; }
        public MetaSwitch(byte meta) { Meta = meta; }
    }
}