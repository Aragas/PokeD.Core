using PokeD.Core.Interfaces;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.Server
{
    public class CreatePlayerPacket : IPacket
    {
        public int PlayerID { get { return int.Parse(DataItems[0], CultureInfo); } set { DataItems[0] = value.ToString(CultureInfo); } }


        public override int ID { get { return (int) PlayerPacketTypes.CreatePlayer; } }

        public override IPacket ReadPacket(IPokeDataReader reader)
        {
            PlayerID = reader.ReadVarInt();

            return this;
        }

        public override IPacket WritePacket(IPokeStream writer)
        {
            writer.WriteVarInt(PlayerID);

            return this;
        }
    }
}
