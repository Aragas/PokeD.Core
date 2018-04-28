using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace PokeD.Core.Services
{
    public class ServiceContainer : IServiceContainer, IEnumerable<IService>, IServiceProvider
    {
        private readonly Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

        private static bool IsAssignableFrom(Type type, object value)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return IsAssignableFromType(type, value.GetType());
        }
        private static bool IsAssignableFromType(Type type, Type objectType)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (objectType == null)
                throw new ArgumentNullException(nameof(objectType));

            if (type.GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()))
                return true;

            return false;
        }

        public void AddService(Type type, object provider)
        {
            var service = provider as IService;

            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (provider == null)
                throw new ArgumentNullException(nameof(provider));
            if (!IsAssignableFrom(type, provider))
                throw new ArgumentException("The provider does not match the specified service type!");

            _services.Add(type, service);
        }
        public void RemoveService(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            _services.Remove(type);
        }
        public object GetService(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (_services.TryGetValue(type, out var service))
                return service;

            return null;
        }

        public void AddService<T>(T provider) where T : class, IService => AddService(typeof(T), provider);
        public void RemoveService<T>() where T : class, IService => RemoveService(typeof(T));
        public T GetService<T>() where T : class, IService => (T) GetService(typeof(T));

        public IEnumerator<IService> GetEnumerator() => _services.Values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}