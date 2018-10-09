using InterfacesLib;
using System;
using System.Collections.Concurrent;
using Faker;

namespace FakerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DllLoader dllLoader = new DllLoader();
            IPlugin plugin = dllLoader.Load(@"D:\учеба\5 семестр\СПП\Faker\RandomPlugin\bin\Debug\RandomPlugin.dll");

            ConcurrentDictionary<Type, IGenerator> dictionary = plugin.GetGenerators();
            Faker.Faker faker = new Faker.Faker(plugin.GetGenerators());

            Sor t = faker.Create<Sor>();

            Console.WriteLine(t.ToString());
            Console.ReadKey();
        }
    }

    public class Sor
    {
        public enum TTR
        {
            TT, RR, EE, WW
        }

        public Foo foo { get; private set; }
        public Bar bar { protected get; set; }

        public Sor(Foo foo, TTR ttr) { }
        public Sor() { }

        public override string ToString()
        {
            return ("{TypeName: " + typeof(Sor).Name + "}");
        }
    }

    public class Foo
    {
        string gg;
        int i;

        public Bar bar { get; set; }
        public int I { get; set; }

        public string K { get; set; }
        private double R { get; set; }
        public string FF { get => gg; set => gg = value; }

        public override string ToString()
        {
            return ("{TypeName: " + typeof(Foo).Name + "}");
        }
    }

    public class Bar
    {
        public Foo foo { get; set; }

        public Bar(Foo foo, int tt, string gg)
        {

        }

        public Bar() { }

        public override string ToString()
        {
            return ("{TypeName: " + typeof(Bar).Name + "}");
        }
    }
}
