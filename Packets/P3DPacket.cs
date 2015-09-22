using System;
using System.Collections.Generic;
using System.Globalization;

using PokeD.Core.Data;

namespace PokeD.Core.Packets
{
    public abstract class P3DPacket : ProtobufPacket
    {
        public static Single ProtocolVersion { get; set; } = 0.5f;
        public DataItems DataItems { get; set; } = new DataItems();

        protected static CultureInfo CultureInfo => CultureInfo.InvariantCulture;

        public static bool TryParseID(string fullData, out int id)
        {
            id = 0;
            return fullData.Contains("|") && int.TryParse(fullData.Split('|')[1], out id);
        }

        public bool TryParseData(string fullData)
        {
            var chunks = fullData.Split('|');

            if (chunks.Length < 5)
                return false;

            if (!string.Equals(ProtocolVersion.ToString(CultureInfo), chunks[0], StringComparison.OrdinalIgnoreCase))
                return false;

            int id;
            if (!int.TryParse(chunks[1], out id))
                return false;

            int origin;
            if (!int.TryParse(chunks[2], out origin))
                return false;
            else
                Origin = origin;

            int dataItemsCount;
            if (!int.TryParse(chunks[3], out dataItemsCount))
                return false;

            var offsetList = new List<int>();

            //Count from 4th item to second last item. Those are the offsets.
            for (var i = 4; i <= dataItemsCount - 1 + 4; i++)
            {
                var offset = 0;
                if (int.TryParse(chunks[i], out offset))
                    offsetList.Add(offset);
                else
                    return false;
            }

            //Set the datastring, its the last item in the list. If it contained any separators, they will get read here:
            var dataString = "";
            for (var i = dataItemsCount + 4; i <= chunks.Length - 1; i++)
            {
                if (i > dataItemsCount + 4)
                    dataString += "|";

                dataString += chunks[i];
            }

            //Cutting the data:
            for (var i = 0; i <= offsetList.Count - 1; i++)
            {
                var cOffset = offsetList[i];
                var length = dataString.Length - cOffset;

                if (i < offsetList.Count - 1)
                    length = offsetList[i + 1] - cOffset;

                DataItems.AddToEnd(dataString.Substring(cOffset, length));
            }

            return true;
        }
    }
}
