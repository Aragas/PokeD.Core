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

        //Task WriteLineAsync(String data);
        //Task<String> ReadLineAsync();
    }

    public interface INetworkTCPClient : INetworkTCPClientAsync, IDisposable
    {
        int DataAvailable { get; }
        Boolean Connected { get; }


        void Connect(String ip, UInt16 port);
        void Disconnect();


        void Send(Byte[] bytes, Int32 offset, Int32 count);
        Int32 Receive(Byte[] buffer, Int32 offset, Int32 count);

        //void WriteLine(String data);
        String ReadLine();

        INetworkTCPClient NewInstance();
    }

    public static class NetworkTCPClientWrapper
    {
        private static INetworkTCPClient _instance;
        public static INetworkTCPClient Instance
        {
            private get
            {
                if (_instance == null)
                    throw new NotImplementedException("This instance is not implemented. You need to implement it in your main project");
                return _instance;
            }
            set { _instance = value; }
        }

        public static INetworkTCPClient NewInstance() { return Instance.NewInstance(); }
    }
}
