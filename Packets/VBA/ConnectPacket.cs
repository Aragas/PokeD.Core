using Aragas.Network.IO;
using Aragas.Network.Packets;

namespace PokeD.Core.Packets.VBA
{
    public class ConnectPacket : VBAPacket
    {
        public byte Field1;
        public byte Field2;

        public override int ID => (int) VBAPacketTypes.Connect;

        public override StandardPacket ReadPacket(StandardDataReader reader)
        {
            Field1 = reader.Read(Field1);
            Field2 = reader.Read(Field2);

            return this;
        }

        public override StandardPacket WritePacket(StandardStream stream)
        {
            stream.Write(Field1);
            stream.Write(Field2);

            return this;
        }
    }
}
