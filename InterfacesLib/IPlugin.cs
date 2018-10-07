using System;
using System.Collections.Concurrent;

namespace InterfacesLib
{
    public interface IPlugin
    {
        ConcurrentDictionary<Type, IGenerator> GetGenerators();
    }
}
