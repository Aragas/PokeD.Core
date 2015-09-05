using System;
using System.Threading.Tasks;

namespace PokeD.Core.Wrappers
{
    public interface INetworkTCPServerAsync
    {
        Task<INetworkTCPClient> AcceptTCPClientAsync();
    }

    public interface INetworkTCPServer : INetworkTCPServerAsync, IDisposable
    {
        ushort Port { get; }
        bool AvailableClients { get; }

        void Start();
        void Stop();

        INetworkTCPClient AcceptNetworkTCPClient();

        INetworkTCPServer NewInstance(ushort port);
    }

    public static class NetworkTCPServerWrapper
    {
        private static INetworkTCPServer _instance;
        public static INetworkTCPServer Instance
        {
            private get
            {
                if (_instance == null)
                    throw new NotImplementedException("This instance is not implemented. You need to implement it in your main project");
                return _instance;
            }
            set { _instance = value; }
        }

        public static INetworkTCPServer NewInstance(ushort port) { return Instance.NewInstance(port); }
    }
}
