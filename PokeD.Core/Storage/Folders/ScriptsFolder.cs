using PCLExt.FileStorage;

namespace PokeD.Core.Storage.Folders
{
    public class LuaModulesFolder : BaseFolder
    {
        public IFile HookFile => GetFile("hook.lua");
        public IFile TranslatorFile => GetFile("translator.lua");

        public LuaModulesFolder() : base(new ScriptsFolder().CreateFolder("Modules", CreationCollisionOption.OpenIfExists)) { }
    }
    public class ScriptsFolder : BaseFolder
    {
        public ScriptsFolder() : base(new MainFolder().CreateFolder("Scripts", CreationCollisionOption.OpenIfExists)) { }
    }
}
