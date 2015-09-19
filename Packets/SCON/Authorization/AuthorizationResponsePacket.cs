using System;
using PokeD.Core.Interfaces;

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

        public override int ID => (int) SCONPacketTypes.AuthorizationResponse;

        public override ProtobufPacket ReadPacket(IPacketDataReader reader)
        {
            AuthorizationStatus = (AuthorizationStatus) reader.ReadByte();

            return this;
        }

        public override ProtobufPacket WritePacket(IPacketStream stream)
        {
            stream.WriteByte((byte) AuthorizationStatus);

            return this;
        }
    }
}