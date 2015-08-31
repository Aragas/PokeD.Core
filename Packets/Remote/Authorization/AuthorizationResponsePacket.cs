using System;
using PokeD.Core.Interfaces;
using PokeD.Core.IO;

namespace PokeD.Core.Packets.Remote.Authorization
{
    [Flags]
    public enum AuthorizationStatus : byte
    {
        RemoteClientEnabled = 1,
        EncryprionEnabled = 2,
        CompressionEnabled = 4
    }

    public class AuthorizationResponsePacket : IPacket
    {
        public AuthorizationStatus AuthorizationStatus { get; set; }

        public override int ID { get { return (int) RemotePacketTypes.AuthorizationResponsePacket; } }

        public override IPacket ReadPacket(IPokeDataReader reader)
        {
            AuthorizationStatus = (AuthorizationStatus) reader.ReadByte();

            return this;
        }

        public override IPacket WritePacket(IPokeStream stream)
        {
            stream.WriteByte((byte) AuthorizationStatus);

            return this;
        }
    }
}