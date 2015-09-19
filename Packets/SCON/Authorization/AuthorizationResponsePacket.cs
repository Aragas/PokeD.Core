using System;
using PokeD.Core.Interfaces;

namespace PokeD.Core.Packets.SCON.Authorization
{
    [Flags]
    public enum AuthorizationStatus : byte
    {
        RemoteClientEnabled = 1,
        EncryprionEnabled = 2,
        CompressionEnabled = 4
    }

    public class AuthorizationResponsePacket : Packet
    {
        public AuthorizationStatus AuthorizationStatus { get; set; }

        public override int ID => (int) SCONPacketTypes.AuthorizationResponse;

        public override Packet ReadPacket(IPacketDataReader reader)
        {
            AuthorizationStatus = (AuthorizationStatus) reader.ReadByte();

            return this;
        }

        public override Packet WritePacket(IPacketStream stream)
        {
            stream.WriteByte((byte) AuthorizationStatus);

            return this;
        }
    }
}