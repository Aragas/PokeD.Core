﻿using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.Server
{
    public class IDPacket : Packet
    {
        public int PlayerID { get { return int.Parse(DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }


        public override int ID => (int) PlayerPacketTypes.ID;

        public override Packet ReadPacket(IPacketDataReader reader)
        {
            PlayerID = reader.ReadVarInt();

            return this;
        }

        public override Packet WritePacket(IPacketStream writer)
        {
            writer.WriteVarInt(PlayerID);

            return this;
        }
    }
}
