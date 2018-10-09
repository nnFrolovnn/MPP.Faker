using InterfacesLib;
using System;

namespace RandomPlugin
{
    class DoubleGenerator : IGenerator
    {
        Random rnd = new Random((int)DateTime.Now.Ticks);

        public object Generate()
        {         
            return rnd.NextDouble() + rnd.Next();
        }
    }
}
