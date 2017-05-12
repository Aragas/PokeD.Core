using PCLExt.FileStorage;

namespace PokeD.Core.Storage.Folders
{
    public class DataFolder : BaseFolder
    {
        public DataFolder() : base(new MainFolder().CreateFolder("Data", CreationCollisionOption.OpenIfExists)) { }
    }
}