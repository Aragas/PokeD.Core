using System;
using System.Threading.Tasks;

namespace PokeD.Core.Wrappers
{
    public interface INetworkTCPClientAsync
    {
        Task ConnectAsync(String ip, UInt16 port);

        Boolean DisconnectAsync();

        Task SendAsync(Byte[] bytes, Int32 offset, Int32 count);

        Task<Int32> ReceiveAsync(Byte[] bytes, Int32 offset, Int32 count);

        Task<String> ReadLineAsync();
    }

    public interface INetworkTcpClient : INetworkTCPClientAsync, IDisposable
    {
        int DataAvailable { get; }
        Boolean Connected { get; }


        void Connect(String ip, UInt16 port);
        void Disconnect();


        void Send(Byte[] bytes, Int32 offset, Int32 count);
        Int32 Receive(Byte[] buffer, Int32 offset, Int32 count);

        void WriteLine(String data);
        String ReadLine();

        INetworkTcpClient NewInstance();
    }

    public static class NetworkTCPClientWrapper
    {
        private static INetworkTcpClient _instance;
        public static INetworkTcpClient Instance
        {
            private get
            {
                if (_instance == null)
                    throw new NotImplementedException("This instance is not implemented. You need to implement it in your main project");
                return _instance;
            }
            set { _instance = value; }
        }

        public static INetworkTcpClient NewInstance() { return Instance.NewInstance(); }
    }
}
