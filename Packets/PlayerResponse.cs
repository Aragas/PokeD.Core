using PokeD.Core.Packets.Battle;
using PokeD.Core.Packets.Chat;
using PokeD.Core.Packets.Client;
using PokeD.Core.Packets.Encryption;
using PokeD.Core.Packets.Server;
using PokeD.Core.Packets.Shared;
using PokeD.Core.Packets.Trade;

namespace PokeD.Core.Packets
{
    public static class PlayerResponse
    {
        public delegate P3DPacket CreatePacketInstance();

        #region Play Response
        public static readonly CreatePacketInstance[] Packets =
        {
            () => new GameDataPacket(),             // 0x00
            () => new GameDataPacket(),             // 0x01
            () => new ChatMessagePrivatePacket(),   // 0x02
            () => new ChatMessagePacket(),          // 0x03
            () => new KickedPacket(),               // 0x04

            null, // 0x05
            null, // 0x06

            () => new IDPacket(),                   // 0x07
            () => new CreatePlayerPacket(),         // 0x08
            () => new DestroyPlayerPacket(),        // 0x09
            () => new ServerClosePacket(),          // 0x0A
            () => new ServerMessagePacket(),        // 0x0B
            () => new WorldDataPacket(),            // 0x0C
            () => new PingPacket(),                 // 0x0D
            () => new GameStateMessagePacket(),     // 0x0E
            null, // 0x0F
            null, // 0x10
            null, // 0x11
            null, // 0x12
            null, // 0x13
            null, // 0x14
            null, // 0x15
            null, // 0x16
            null, // 0x17
            null, // 0x18
            null, // 0x19
            null, // 0x1A
            null, // 0x1B
            null, // 0x1C
            null, // 0x1D
            () => new TradeRequestPacket(),         // 0x1E
            () => new TradeJoinPacket(),            // 0x1F
            () => new TradeQuitPacket(),            // 0x20
            () => new TradeOfferPacket(),           // 0x21
            () => new TradeStartPacket(),           // 0x22
            null, // 0x23
            null, // 0x24
            null, // 0x25
            null, // 0x26
            null, // 0x27
            null, // 0x28
            null, // 0x29
            null, // 0x2A
            null, // 0x2B
            null, // 0x2C
            null, // 0x2D
            null, // 0x2E
            null, // 0x2F
            null, // 0x30
            null, // 0x31
            () => new BattleRequestPacket(),        // 0x32
            () => new BattleJoinPacket(),           // 0x33
            () => new BattleQuitPacket(),           // 0x34 
            () => new BattleOfferPacket(),          // 0x35
            () => new BattleStartPacket(),          // 0x36
            () => new BattleClientDataPacket(),     // 0x37
            () => new BattleHostDataPacket(),       // 0x38
            () => new BattlePokemonDataPacket(),    // 0x39
            null, // 0x3A
            null, // 0x3B
            null, // 0x3C
            null, // 0x3D
            null, // 0x3E
            null, // 0x3F
            null, // 0x40
            null, // 0x41
            null, // 0x42
            null, // 0x43
            null, // 0x44
            null, // 0x45
            null, // 0x46
            null, // 0x47
            null, // 0x48
            null, // 0x49
            null, // 0x4A
            null, // 0x4B
            null, // 0x4C
            null, // 0x4D
            null, // 0x4E
            null, // 0x4F

            () => new EncryptionRequestPacket(),    // 0x50
            () => new EncryptionResponsePacket(),   // 0x51
            () => new JoiningGameRequestPacket(),   // 0x52
            () => new JoiningGameResponsePacket(),  // 0x53

            null, // 0x54
            null, // 0x55
            null, // 0x56
            null, // 0x57
            null, // 0x58
            null, // 0x59
            null, // 0x5A
            null, // 0x5B
            null, // 0x5C
            null, // 0x5D
            null, // 0x5E
            null, // 0x5F
            null, // 0x60
            null, // 0x61
            () => new ServerInfoDataPacket(),       // 0x62
            () => new ServerDataRequestPacket(),     // 0x63
            null, // 0x64
            null, // 0x65
        };
        #endregion
    }
}
