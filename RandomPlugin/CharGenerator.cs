using InterfacesLib;
using System;

namespace RandomPlugin
{
    class CharGenerator : IGenerator
    {
        Random rnd = new Random((int)DateTime.Now.Ticks);

        public object Generate()
        {
            return (char)(rnd.Next() + 1);
        }
    }
}
