using InterfacesLib;
using System;
using System.Collections.Concurrent;

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

            return dictionary;
        }
    }
}
