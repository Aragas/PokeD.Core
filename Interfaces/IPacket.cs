using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using PokeD.Core.Data;
using PokeD.Core.IO;
using PokeD.Core.Packets.Server;

namespace PokeD.Core.Interfaces
{
    /*
        Single ProtocolVersion { get; }
        Int32 ID { get; }
        Int32 Origin { get; set; }
        Int32 NetworkMode { get; }
    */

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

        public void ParseData(string str)
        {
            //ProtocolVersion = ParseProtocolVersion(str);
            //Origin = ParseOrigin(str);
            //DataItems = new DataItems(ParseDataItems(str));
            IsValid(str);
        }

        public static float ParseProtocolVersion(string data)
        {
            return float.Parse(data.Split('|')[0], CultureInfo.InvariantCulture);
        }

        public static int ParseID(string data)
        {
             return int.Parse(data.Split('|')[1], CultureInfo.InvariantCulture);
        }

        public static int ParseOrigin(string data)
        {
            return int.Parse(data.Split('|')[2], CultureInfo.InvariantCulture);
        }

        public static int ParseDataCount(string data)
        {
            return int.Parse(data.Split('|')[3], CultureInfo.InvariantCulture);
        }

        public static string[] ParseDataItems(string data)
        {
            return data.Split('|').Skip(5).ToArray();
        }

        public bool IsValid(string fullData)
        {
            var isValid = true;


            if (fullData == null)
            {
                isValid = false;
            }
            else
            {
                char[] separator = new char[] { '|' };
                List<string> list = fullData.Split(separator).ToList<string>();
                if (list.Count >= 5)
                {
                    ProtocolVersion = float.Parse(list[0], CultureInfo.InvariantCulture);
                    Origin = int.Parse(list[2]);


                    int num = int.Parse(list[3]);
                    List<int> list2 = new List<int>();
                    int num3 = (num - 1) + 4;
                    for (int i = 4; i <= num3; i++)
                    {
                        list2.Add(int.Parse(list[i]));
                    }
                    string str = "";
                    int num8 = num + 4;
                    int num6 = list.Count - 1;
                    for (int j = num8; j <= num6; j++)
                    {
                        if (j > (num + 4))
                        {
                            str = str + "|";
                        }
                        str = str + list[j];
                    }
                    int num10 = list2.Count - 1;
                    for (int k = 0; k <= num10; k++)
                    {
                        int startIndex = list2[k];
                        int length = str.Length - startIndex;
                        if (k < (list2.Count - 1))
                        {
                            length = list2[k + 1] - startIndex;
                        }
                        DataItems.Add(str.Substring(startIndex, length));
                    }
                }
                else
                {
                    isValid = false;
                }
            }

            return isValid;
        }
    }
}
