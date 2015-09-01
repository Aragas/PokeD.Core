using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using PokeD.Core.Data;
using PokeD.Core.IO;

namespace PokeD.Core.Interfaces
{
    public abstract class IPacket
    {
        public static CultureInfo CultureInfo {  get { return CultureInfo.InvariantCulture; } }

        public Single ProtocolVersion { get; set; }
        public abstract Int32 ID { get; }
        public Int32 Origin { get; set; }

        public DataItems DataItems = new DataItems();


        /// <summary>
        /// Read packet from any stream.
        /// </summary>
        public abstract IPacket ReadPacket(IPokeDataReader reader);

        /// <summary>
        /// Write packet to any stream.
        /// </summary>
        public abstract IPacket WritePacket(IPokeStream writer);

        public IPacket ParseData(string str)
        {
            try
            {
                ProtocolVersion = ParseProtocolVersion(str);
                Origin = ParseOrigin(str);
                DataItems = BuildDataItems(str);
            }
            catch (Exception) { return null; }
            
            return this;
        }


        public static bool DataIsValid(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                if (!data.Contains("|"))
                    return false;

                // TODO: Nope
                if (data.Split('|')[0] != 0.5f.ToString(CultureInfo.InvariantCulture))
                    return false;

                int dataCount = 0;
                if (!int.TryParse(data.Split('|')[3], out dataCount))
                    return false;

                if (dataCount < 0)
                    return false;

                int num2 = 0;
                if (!int.TryParse(data.Split('|')[3 + dataCount], out num2))
                    return false;

                if (num2 < 0)
                    return false;

                try
                {
                    var indexof = data.IndexOf(num2.ToString(), StringComparison.Ordinal) + 3;
                    if (indexof < data.Length)
                    {
                        var source = data.Substring(indexof);
                        return (source.Length >= num2);
                    }
                }
                catch (Exception) { return false; }
            }

            return false;
        }


        private static float ParseProtocolVersion(string data)
        {
            return float.Parse(data.Split('|')[0], CultureInfo.InvariantCulture);
        }

        public static bool TryParseID(string data, out int id)
        {
             return int.TryParse(data.Split('|')[1], out id);
        }

        private static int ParseID(string data)
        {
            return int.Parse(data.Split('|')[1]);
        }

        private static int ParseOrigin(string data)
        {
            return int.Parse(data.Split('|')[2], CultureInfo.InvariantCulture);
        }

        private static int ParseDataCount(string data)
        {
            return int.Parse(data.Split('|')[3], CultureInfo.InvariantCulture);
        }

        private static string[] ParseDataItems(string data)
        {
            return data.Split('|').Skip(5).ToArray();
        }


        private static DataItems BuildDataItems(string data)
        {
            try
            {

                var dataCount = ParseDataCount(data);
                string item;
                var items = new List<string>();
                int count = 0;
                if (dataCount == 1)
                {
                    item = data.Substring((ParseProtocolVersion(data).ToString(CultureInfo).Length + 1) + (ParseID(data).ToString().Length + 1) + (ParseOrigin(data).ToString().Length + 1) + (dataCount.ToString().Length + 1) + 2);
                    items.Add(item);
                    return new DataItems(items);
                }
                item = data.Substring((ParseProtocolVersion(data).ToString(CultureInfo).Length + 1) + (ParseID(data).ToString().Length + 1) + (ParseOrigin(data).ToString().Length + 1) + (dataCount.ToString().Length) + 1);
                for (int i = 1; i <= dataCount; i++)
                    item = item.Substring(item.IndexOf("|", StringComparison.Ordinal) + 1);

                int num8 = 4 + dataCount;
                for (int j = 4; j <= num8; j++)
                {
                    if (j == 4)
                        count = 0;
                    
                    else if ((j > 4) & (j < (4 + dataCount)))
                    {
                        if (int.Parse(data.Split('|')[j]) == count)
                            items.Add("");
                        else
                        {
                            if (int.Parse(data.Split('|')[j]) >= item.Length)
                                items.Add(item.Remove(0, count));
                            else
                                items.Add(item.Remove(int.Parse(data.Split('|')[j])).Remove(0, count));

                            count = int.Parse(data.Split('|')[j]);
                        }
                    }
                    else
                        items.Add(item.Remove(0, count));
                }
                return new DataItems(items);
            }
            catch (Exception)
            {
                return new DataItems("");
            }
        }
    }
}
