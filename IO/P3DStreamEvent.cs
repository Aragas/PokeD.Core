using System;

using Aragas.Network.IO;

using PCLExt.Network;

namespace PokeD.Core.IO
{
    public class P3DStreamEvent : P3DStream
    {
        public event PacketStreamConnectedEventArgs Connected;
        public event PacketStreamDataReceivedEventArgs DataReceived;
        public event PacketStreamDisconnectedEventArgs Disconnected;

        public override string Host => Socket.RemoteEndPoint.IP;
        public override ushort Port => Socket.RemoteEndPoint.Port;
        public override bool IsConnected => Socket.IsConnected;
        public override int DataAvailable => Socket?.DataAvailable ?? 0;

        private ISocketClientEvent Socket { get; }


        public P3DStreamEvent(ISocketClientEvent socket, bool isServer = false) : base(socket, isServer)
        {
            Socket = socket;
            Socket.Connected += (e) => Connected?.Invoke(new PacketStreamConnectedArgs(this));
            Socket.DataReceived += (e) => DataReceived?.Invoke(new PacketStreamDataReceivedArgs(this, e.Data));
            Socket.Disconnected += (e) => Disconnected?.Invoke(new PacketStreamDisconnectedArgs(this, e.Reason));
        }


        public void Send(byte[] buffer) { Socket.Write(buffer, 0, buffer.Length); }
        public byte[] Receive(int length) { throw new NotSupportedException(); }
    }
}
