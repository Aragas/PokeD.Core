using PokeD.Core.Interfaces;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.Server
{
    public class ServerMessagePacket : IPacket
    {
        public string Message { get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override int ID { get { return (int) PacketTypes.ServerClose; } }

        public override IPacket ReadPacket(IPokeDataReader reader)
        {
            Message = reader.ReadString();

            return this;
        }

        public override IPacket WritePacket(IPokeStream writer)
        {
            writer.WriteString(Message);

            return this;
        }
    }
}
