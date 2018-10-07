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

            ConcurrentDictionary<Type, IGenerator> dictionary = plugin.GetGenerators();
            Faker.Faker faker = new Faker.Faker(plugin.GetGenerators());

            Foo foo = faker.Create<Foo>();


            Console.ReadKey();
        }
    }



    public class Foo
    {
        string gg;
        int i;

        public int I { get; set; }

        public string K { get; }
        private double R { get; set; }
        public string FF { set => gg = value; }
    }
}
