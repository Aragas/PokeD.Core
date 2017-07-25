using PCLExt.FileStorage;
using PCLExt.FileStorage.Folders;

namespace PokeD.Core.Storage.Folders
{
    public class DataFolder : BaseFolder
    {
        public DataFolder() : base(new ApplicationFolder().CreateFolder("Data", CreationCollisionOption.OpenIfExists)) { }
    }
}