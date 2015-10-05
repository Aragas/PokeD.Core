using System;
using Aragas.Core.Data;
using Aragas.Core.Interfaces;
using Aragas.Core.Packets;

namespace PokeD.Core.Packets.SCON.Authorization
{
    [Flags]
    public enum AuthorizationStatus : byte
    {
        RemoteClientEnabled = 1,
        EncryprionEnabled = 2
    }

    public class AuthorizationResponsePacket : ProtobufPacket
    {
        public AuthorizationStatus AuthorizationStatus { get; set; }

        public override VarInt ID => (int) SCONPacketTypes.AuthorizationResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            AuthorizationStatus = (AuthorizationStatus) reader.ReadByte();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.Write((byte) AuthorizationStatus);

            return this;
        }
    }
}