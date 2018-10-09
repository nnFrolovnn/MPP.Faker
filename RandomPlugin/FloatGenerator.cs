using InterfacesLib;
using System;

namespace RandomPlugin
{
    class FloatGenerator : IGenerator
    {
        Random rnd = new Random((int)DateTime.Now.Ticks);

        public object Generate()
        {
            return (float)(rnd.NextDouble() + rnd.Next());
        }
    }
}
