using Aragas.Core.Data;
using Aragas.Core.Extensions;

namespace PokeD.Core.Data.PokeD.Structs
{
    public class MetaPosition
    {
        public long Meta { get; private set; }
        
        public Vector3 Position
        {
            get { return Vector3.FromFixedPoint(Meta.BitsGet(0, 12), Meta.BitsGet(24, 32), Meta.BitsGet(12, 24)); }
            set
            {
                Meta = Meta.BitsSet((long) (value.X * 32.0f), 0, 12);
                Meta = Meta.BitsSet((long) (value.Y * 32.0f), 24, 32);
                Meta = Meta.BitsSet((long) (value.Z * 32.0f), 12, 24);
            }
        }


        public MetaPosition(Vector3 position) { Position = position; }
        public MetaPosition(long meta) { Meta = meta; }
    }
}