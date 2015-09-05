using System;

namespace PokeD.Core.Wrappers
{
    public interface INetworkTCPClient : IDisposable
    {
        string IP { get; }
        Boolean Connected { get; }
        int DataAvailable { get; }


        void Connect(String ip, UInt16 port);
        void Disconnect();


        void Send(Byte[] bytes, Int32 offset, Int32 count);
        Int32 Receive(Byte[] buffer, Int32 offset, Int32 count);


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
