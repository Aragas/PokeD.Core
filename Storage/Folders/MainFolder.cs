using PCLExt.FileStorage;

namespace PokeD.Core.Storage.Folders
{
    public class MainFolder : BaseFolder
    {
        public MainFolder() : base(FileSystem.SpecialStorage) { }
    }
}