using Aragas.Network.Data;
using Aragas.Network.IO;
using Aragas.Network.Packets;

using PokeD.Core.Data.SCON;

namespace PokeD.Core.Packets.SCON.Status
{
    public class BanListResponsePacket : SCONPacket
    {
        public Ban[] Bans { get; set; } = new Ban[0];


        public override VarInt ID => SCONPacketTypes.BanListResponse;

        public override void Deserialize(ProtobufDeserialiser deserialiser)
        {
            Bans = deserialiser.Read(Bans);
        }
        public override void Serialize(ProtobufSerializer serializer)
        {
            serializer.Write(Bans);
        }
    }
}
