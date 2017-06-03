namespace PokeD.Core.Components
{
    public interface IComponentContainer
    {
        void AddComponent<T>(T provider) where T : class, IComponent;
        T GetComponent<T>() where T : class, IComponent;
    }
}