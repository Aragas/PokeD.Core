using System.Globalization;
using System.Text;

using Aragas.Network.Data;

namespace PokeD.Core.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 FromPokeString(string @string, char gameSeparator, CultureInfo cultureInfo)
        {
            var systemSeparator = cultureInfo.NumberFormat.NumberDecimalSeparator[0];

            @string = @string.Replace(gameSeparator, systemSeparator);
            var data = @string.Split('|');

            if (data.Length != 3)
                return Vector3.Zero;

            float x, y, z;
            var xb = float.TryParse(data[0], NumberStyles.AllowDecimalPoint, cultureInfo, out x);
            var yb = float.TryParse(data[1], NumberStyles.AllowDecimalPoint, cultureInfo, out y);
            var zb = float.TryParse(data[2], NumberStyles.AllowDecimalPoint, cultureInfo, out z);

            if (xb && yb && zb)
                return new Vector3(x * 1000 / 1000, y * 1000 / 1000, z * 1000 / 1000);
            else
                return Vector3.Zero;
        }
        public static string ToPokeString(this Vector3 vector3, char gameSeparator, CultureInfo cultureInfo)
        {
            var systemSeparator = cultureInfo.NumberFormat.NumberDecimalSeparator[0];

            var data = new StringBuilder();
            data.Append((vector3.X * 1000 / 1000).ToString(cultureInfo).Replace(systemSeparator, gameSeparator));
            data.Append("|");
            data.Append((vector3.Y * 1000 / 1000).ToString(cultureInfo).Replace(systemSeparator, gameSeparator));
            data.Append("|");
            data.Append((vector3.Z * 1000 / 1000).ToString(cultureInfo).Replace(systemSeparator, gameSeparator));

            return data.ToString();
        }
    }
}