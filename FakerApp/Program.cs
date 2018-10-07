using InterfacesLib;
using System;
using System.Collections.Concurrent;

namespace FakerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DllLoader dllLoader = new DllLoader();
            IPlugin plugin = dllLoader.Load(@"D:\учеба\5 семестр\СПП\Faker\Plugin\bin\Debug\Plugin.dll");

            ConcurrentDictionary<Type, IGenerator<object>> dictionary = plugin.GetGenerators();

            IGenerator<object> generator;
            bool isgot = dictionary.TryGetValue(typeof(string), out generator);

            if (isgot)
            {
                foreach (var i in dictionary.Values)
                {
                    Console.WriteLine(i.ToString());
                }
            }

            Console.WriteLine(generator.Generate());
            Console.WriteLine((string)generator.Generate());
            Console.ReadKey();
        }
    }
}
