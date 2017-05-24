using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

using PCLExt.FileStorage;

using PokeD.Core.Data.PokeApi;
using PokeD.Core.Storage.Folders;

namespace PokeD.Core.Storage.Files
{
    public class PokeApiFile : BaseFile
    {
        private class ZipStruct : IDisposable
        {
            private MemoryStream ZipStream { get; } = new MemoryStream();
            private ZipArchive Zip { get; }

            public ZipStruct(Stream stream)
            {
                var pos = stream.Position;

                stream.Position = 0;
                stream.CopyTo(ZipStream);

                stream.Position = pos;

                Zip = new ZipArchive(ZipStream);
            }

            public PokeApiV2Json Get(ResourceUri resourceUri)
            {
                var resourceName = $"{resourceUri.Type}_{resourceUri.ID}";
                var zipEntry = Zip.Entries.SingleOrDefault(entry => PortablePath.GetFileNameWithoutExtension(entry.Name) == resourceName);
                if (zipEntry == null)
                    return null;

                using (var stream = zipEntry.Open())
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                    return PokeApiV2Json.Deserialize(resourceUri, reader.ReadToEnd());
            }
            public bool Contains(ResourceUri resourceUri) => Zip.Entries.SingleOrDefault(entry => PortablePath.GetFileNameWithoutExtension(entry.Name).Replace('_', '/') == $"{resourceUri.Type}/{resourceUri.ID}") != null;

            public void Dispose()
            {
                Zip.Dispose();
                ZipStream.Dispose();
            }
        }
        private ZipStruct Zip { get; }

        private Dictionary<string, PokeApiV2Json> Files { get; } = new Dictionary<string, PokeApiV2Json>();

        private bool InMemory { get; }

        public PokeApiFile(bool inMemory = false) : base(new PokeApiCacheFolder().CreateFile("PokeApi.zip", CreationCollisionOption.OpenIfExists))
        {
            InMemory = inMemory;

            if (InMemory)
            {
                using (var fs = Open(FileAccess.ReadAndWrite))
                using (var zip = new ZipArchive(fs))
                {
                    foreach (var zipEntry in zip.Entries)
                    {
                        if (string.IsNullOrEmpty(zipEntry.Name))
                            continue;

                        using (var stream = zipEntry.Open())
                        using (var reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            var id = PortablePath.GetFileNameWithoutExtension(zipEntry.Name).Replace('_', '/');
                            var json = reader.ReadToEnd();
                            Files.Add(id, PokeApiV2Json.Deserialize(id, json));
                        }
                    }
                }
            }
            else
            {
                using (var fs = Open(FileAccess.ReadAndWrite))
                    Zip = new ZipStruct(fs);
            }
        }

        public PokeApiV2Json Get(ResourceUri resourceUri) => InMemory ? Files[$"{resourceUri.Type}/{resourceUri.ID}"] : Zip.Get(resourceUri);
        public bool Contains(ResourceUri resourceUri) => InMemory ? Files.ContainsKey($"{resourceUri.Type}/{resourceUri.ID}") : Zip.Contains(resourceUri);
    }
}
