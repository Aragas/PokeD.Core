using Aragas.Core.Data;
using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.PokeD.Battle
{
    /// <summary>
    /// From Server
    /// </summary>
    public class BattleCancelledPacket : PokeDPacket
    {
        public string Reason { get; set; } = string.Empty;


        public override VarInt ID => PokeDPacketTypes.BattleCancelled;

        public override ProtobufPacket ReadPacket(ProtobufDataReader reader)
        {
            Reason = reader.Read(Reason);

            return this;
        }

        public override ProtobufPacket WritePacket(ProtobufStream writer)
        {
            writer.Write(Reason);

            return this;
        }
    }
}
