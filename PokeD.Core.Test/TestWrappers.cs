using System;
using System.IO;
using System.Reflection;

using Aragas.Core.Wrappers;

using PCLStorage;

namespace PokeD.Core.Test
{
    public class TestITCPClient : ITCPClient
    {
        private MemoryStream Stream { get; } = new MemoryStream();


        public string IP => "NONE";
        public ushort Port => 0;
        public bool Connected => true;
        public int DataAvailable => (int)(Stream.Position - Stream.Length);


        public Stream GetStream() => Stream;


        public ITCPClient Connect(string ip, ushort port) { return this; }
        public ITCPClient Disconnect() { return this; }


        public void Dispose() { }
    }
    public class TestIAppDomain : IAppDomain
    {
        public Assembly GetAssembly(Type type) => Assembly.GetAssembly(type);

        public Assembly[] GetAssemblies() => AppDomain.CurrentDomain.GetAssemblies();

        public Assembly LoadAssembly(byte[] assemblyData) => Assembly.Load(assemblyData);
    }
    public class TestIFileSystem : Aragas.Core.Wrappers.IFileSystem
    {
        public IFolder SettingsFolder { get; }
        public IFolder LogFolder { get; }
        public IFolder CrashLogFolder { get; }
        public IFolder LuaFolder { get; }
        public IFolder AssemblyFolder { get; }
        public IFolder DatabaseFolder { get; }
        public IFolder ContentFolder { get; }
        public IFolder OutputFolder { get; }

        public TestIFileSystem()
        {
            var baseDirectory = FileSystem.Current.GetFolderFromPathAsync(AppDomain.CurrentDomain.BaseDirectory).Result;

            DatabaseFolder  = baseDirectory.CreateFolderAsync("Database", CreationCollisionOption.OpenIfExists).Result;
            ContentFolder   = baseDirectory.CreateFolderAsync("Content", CreationCollisionOption.OpenIfExists).Result;
        }
    }
}
