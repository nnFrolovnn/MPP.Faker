using InterfacesLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPlugin
{
    class ICollectionFloatGenerator : IGenerator
    {
        Random rnd = new Random((int)DateTime.Now.Ticks);

        public object Generate()
        {
            return new Collection<double> { (float)rnd.NextDouble(), (float)rnd.NextDouble() };
        }
    }
}
