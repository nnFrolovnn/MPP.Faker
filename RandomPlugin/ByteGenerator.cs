using InterfacesLib;
using System;

namespace RandomPlugin
{
    class ByteGenerator : IGenerator
    {
        Random rnd = new Random((int)DateTime.Now.Ticks);

        public object Generate()
        {
            return (byte)(rnd.Next() + 1);
        }
    }
}
