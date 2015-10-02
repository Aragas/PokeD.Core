using System;
using System.Collections.Generic;
using System.Reflection;

namespace PokeD.Core.Wrappers
{
    public interface IAppDomain
    {
        Assembly GetCallingAssembly();
        Assembly[] GetAssemblies();
        Assembly LoadAssembly(byte[] assemblyData);
    }

    public static class AppDomainWrapper
    {
        private static IAppDomain _instance;
        public static IAppDomain Instance
        {
            private get
            {
                if (_instance == null)
                    throw new NotImplementedException(
                        "This instance is not implemented. You need to implement it in your main project");
                return _instance;
            }
            set { _instance = value; }
        }

        public static Assembly GetCallingAssembly() { return Instance.GetCallingAssembly(); }
        public static Assembly[] GetAssemblies() { return Instance.GetAssemblies(); }
        public static Assembly LoadAssembly(byte[] assemblyData) { return Instance.LoadAssembly(assemblyData); }

        public static T GetTypeFromNameAndInterface<T>(string className)
        {
            foreach (var typeInfo in new List<TypeInfo>(GetCallingAssembly().DefinedTypes))
                if (typeInfo.Name == className)
                    foreach (var type in new List<Type>(typeInfo.ImplementedInterfaces))
                        if (type == typeof (T))
                            return (T) Activator.CreateInstance(typeInfo.AsType());

            return default(T);
        }
        public static T GetTypeFromNameAndAbstract<T>(string className)
        {
            foreach (var typeInfo in new List<TypeInfo>(GetCallingAssembly().DefinedTypes))
                if (typeInfo.Name == className)
                    if (typeInfo.IsSubclassOf(typeof (T)))
                        return (T) Activator.CreateInstance(typeInfo.AsType());

            return default(T);
        }
        public static object GetTypeFromName(string className)
        {
            foreach (var typeInfo in new List<TypeInfo>(GetCallingAssembly().DefinedTypes))
                if (typeInfo.Name == className)
                    return Activator.CreateInstance(typeInfo.AsType());

            return null;
        }
    }
}
