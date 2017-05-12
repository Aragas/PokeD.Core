using PCLExt.FileStorage;

namespace PokeD.Core.Storage.Folders
{
    public class PokeApiCacheFolder : BaseFolder
    {
        public PokeApiCacheFolder() : base(new DataFolder().CreateFolder("PokeApiCache", CreationCollisionOption.OpenIfExists)) { }
    }
}