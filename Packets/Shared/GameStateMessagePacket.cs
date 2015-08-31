using PokeD.Core.Interfaces;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.Shared
{
    public class GameStateMessagePacket : IPacket
    {
        public string EventMessage {  get { return DataItems[0]; } set { DataItems[0] = value; } }


        public override int ID { get { return (int) PlayerPacketTypes.GameStateMessage; } }
        
        public override IPacket ReadPacket(IPokeDataReader reader)
        {
            EventMessage = reader.ReadString();

            return this;
        }

        public override IPacket WritePacket(IPokeStream writer)
        {
            writer.WriteString(EventMessage);

            return this;
        }
    }
}
