using InterfacesLib;
using System;
using System.Collections.Concurrent;

namespace Plugin
{
    public class Plugin: IPlugin
    {
        public ConcurrentDictionary<Type, IGenerator<object>> GetGenerators()
        {
            ConcurrentDictionary<Type, IGenerator<object>> dictionary = new ConcurrentDictionary<Type, IGenerator<object>>();

            dictionary.TryAdd(typeof(string), (IGenerator<object>)new StringGenerator());
            dictionary.TryAdd(typeof(int), (IGenerator<object>)new IntGenerator());
            dictionary.TryAdd(typeof(bool), (IGenerator<object>)new BoolGenerator());
            dictionary.TryAdd(typeof(long), (IGenerator<object>)new LongGenerator());
            dictionary.TryAdd(typeof(double), (IGenerator<object>)new DoubleGenerator());
            dictionary.TryAdd(typeof(float), (IGenerator<object>)new FloatGenerator());
            dictionary.TryAdd(typeof(char), (IGenerator<object>)new CharGenerator());
            dictionary.TryAdd(typeof(byte), (IGenerator<object>)new ByteGenerator());
            dictionary.TryAdd(typeof(DateTime), (IGenerator<object>)new DateTimeGenerator());

            return dictionary;
        }
    }
}
