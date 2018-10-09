using InterfacesLib;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RandomPlugin
{
    public class RandPlugin : IPlugin
    {
        public ConcurrentDictionary<Type, IGenerator> GetGenerators()
        {
            ConcurrentDictionary<Type, IGenerator> dictionary = new ConcurrentDictionary<Type, IGenerator>();

            dictionary.TryAdd(typeof(string), new StringGenerator());
            dictionary.TryAdd(typeof(int), new IntGenerator());
            dictionary.TryAdd(typeof(bool), new BoolGenerator());
            dictionary.TryAdd(typeof(long), new LongGenerator());
            dictionary.TryAdd(typeof(double), new DoubleGenerator());
            dictionary.TryAdd(typeof(float), new FloatGenerator());
            dictionary.TryAdd(typeof(char), new CharGenerator());
            dictionary.TryAdd(typeof(byte), new ByteGenerator());
            dictionary.TryAdd(typeof(DateTime), new DateTimeGenerator());
            dictionary.TryAdd(typeof(Collection<int>), new ICollectionIntGenerator());
            dictionary.TryAdd(typeof(Collection<double>), new ICollectionDoubleGenerator());
            dictionary.TryAdd(typeof(Collection<float>), new ICollectionFloatGenerator());
            dictionary.TryAdd(typeof(List<int>), new IListIntGenerator());

            return dictionary;
        }
    }
}
