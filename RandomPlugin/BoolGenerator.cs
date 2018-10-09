using InterfacesLib;
using System;

namespace RandomPlugin
{
    class BoolGenerator : IGenerator
    {
        public object Generate()
        {
            return true;
        }
    }
}
