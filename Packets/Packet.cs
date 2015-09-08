using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using PokeD.Core.Data;
using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets
{
    public abstract class Packet
    {
        public Single ProtocolVersion { get; set; }
        public abstract Int32 ID { get; }
        public Int32 Origin { get; set; }
        public DataItems DataItems = new DataItems();

        protected static CultureInfo CultureInfo => CultureInfo.InvariantCulture;


        /// <summary>
        /// Read packet from IPokeDataReader.
        /// </summary>
        public abstract Packet ReadPacket(IPacketDataReader reader);

        /// <summary>
        /// Write packet to IPokeStream.
        /// </summary>
        public abstract Packet WritePacket(IPacketStream writer);


        public static bool TryParseID(string fullData, out int id)
        {
            id = 0;
            return fullData.Contains("|") && int.TryParse(fullData.Split('|')[1], out id);
        }

        public bool TryParseData(string fullData)
        {
            var chunks = fullData.Split('|').ToList();

            if (chunks.Count < 5)
                return false;

            //if (!string.Equals(ProtocolVersion.ToString(CultureInfo), chunks[0], StringComparison.OrdinalIgnoreCase))
            //    return false;

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
            string dataString = "";
            for (var i = dataItemsCount + 4; i <= chunks.Count - 1; i++)
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

                DataItems.Add(dataString.Substring(cOffset, length));
            }

            return true;
        }
    }
}
