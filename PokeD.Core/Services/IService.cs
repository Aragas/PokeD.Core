using System;

namespace PokeD.Core.Services
{
    public interface IService : IDisposable
    {
        IServiceContainer Services { get; }
    }
}