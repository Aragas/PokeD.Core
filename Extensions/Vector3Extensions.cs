using System.Globalization;
using System.Text;

using PokeD.Core.Data;

namespace PokeD.Core.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 FromPokeString(string @string, char separator)
        {
            @string = @string.Replace(separator, ',');
            var data = @string.Split('|');

            if (data.Length != 3)
                return Vector3.Zero;

            float x, y, z;
            var xb = float.TryParse(data[0], out x);
            var yb = float.TryParse(data[1], out y);
            var zb = float.TryParse(data[2], out z);

            if (xb && yb && zb)
                return new Vector3(x * 100 / 100, y * 100 / 100, z * 100 / 100);
            else
                return Vector3.Zero;
        }
        public static string ToPokeString(this Vector3 vector3, char separator, CultureInfo cultureInfo)
        {
            var data = new StringBuilder();
            data.Append((vector3.X * 1000 / 1000).ToString(cultureInfo).Replace('.', separator));
            data.Append("|");
            data.Append((vector3.Y * 1000 / 1000).ToString(cultureInfo).Replace('.', separator));
            data.Append("|");
            data.Append((vector3.Z * 1000 / 1000).ToString(cultureInfo).Replace('.', separator));

            return data.ToString();
        }
    }
}