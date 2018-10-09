using InterfacesLib;
using System;
using System.Collections.ObjectModel;

namespace RandomPlugin
{
    class ICollectionIntGenerator : IGenerator
    {
        Random rnd = new Random((int)DateTime.Now.Ticks);

        public object Generate()
        {
            return new Collection<int> { rnd.Next(), rnd.Next() };
        }
    }
}
