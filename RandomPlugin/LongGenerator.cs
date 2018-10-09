using InterfacesLib;
using System;

namespace RandomPlugin
{
    class LongGenerator : IGenerator
    {
        Random rnd = new Random((int)DateTime.Now.Ticks);

        public object Generate()
        {
            return rnd.Next();
        }
    }
}
