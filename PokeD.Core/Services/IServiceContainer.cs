namespace PokeD.Core.Services
{
    public interface IServiceContainer
    {
        T GetService<T>() where T : class, IService;
        void AddService<T>(T component) where T : class, IService;
        void RemoveService<T>() where T : class, IService;
    }
}