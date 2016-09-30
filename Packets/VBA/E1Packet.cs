using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.VBA
{
    public class E1Packet : VBAPacket
    {
        public byte[] Data;

        public override int ID => (int) VBAPacketTypes.E1;

        public override StandardPacket ReadPacket(StandardDataReader reader)
        {
            Data = reader.Read(Data, reader.BytesLeft());

            return this;
        }

        public override StandardPacket WritePacket(StandardStream stream)
        {
            stream.Write(Data);

            return this;
        }
    }
}
