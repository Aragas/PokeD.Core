using System;

using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Overworld
{
    public class WorldInfoPacketcs : PokeDPacket
    {
        public TimeSpan Time { get; set; }
        public byte Season { get; set; }
        public byte Weather { get; set; }
        public byte Event { get; set; }

        public override VarInt ID => PokeDPacketTypes.WorldInfo;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            Time = reader.Read(Time);
            Season = reader.Read(Season);
            Weather = reader.Read(Weather);
            Event = reader.Read(Event);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream writer)
        {
            writer.Write(Time);
            writer.Write(Season);
            writer.Write(Weather);
            writer.Write(Event);

            return this;
        }
    }
}
