using PCLExt.FileStorage;
using PCLExt.FileStorage.Folders;

namespace PokeD.Core.Storage.Folders
{
    public class MainFolder : BaseFolder
    {
        public MainFolder() : base(new ApplicationFolder()) { }
    }
}