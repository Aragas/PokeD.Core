﻿using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Trade
{
    public class TradeQuitPacket : Packet
    {
        public int DestinationPlayerID { get { return int.Parse(DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }


        public override int ID => (int) PlayerPacketTypes.TradeQuit;

        public override Packet ReadPacket(IPacketDataReader reader)
        {
            if (reader.IsServer)
                DestinationPlayerID = reader.ReadVarInt();

            return this;
        }

        public override Packet WritePacket(IPacketStream writer)
        {
            if (!writer.IsServer)
                writer.WriteVarInt(DestinationPlayerID);

            return this;
        }
    }
}
