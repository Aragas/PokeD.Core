using System;

using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets
{
    public abstract class ProtobufPacket
    {
        public abstract Int32 ID { get; }

        public Int32 Origin { get; set; }

        /// <summary>
        /// Read packet from IPokeDataReader.
        /// </summary>
        public abstract ProtobufPacket ReadPacket(IPacketDataReader reader);

        /// <summary>
        /// Write packet to IPokeStream.
        /// </summary>
        public abstract ProtobufPacket WritePacket(IPacketStream writer);
    }
}
