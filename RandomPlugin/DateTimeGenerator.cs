using InterfacesLib;
using System;

namespace RandomPlugin
{
    class DateTimeGenerator : IGenerator
    {
        Random rnd = new Random((int)DateTime.Now.Ticks);

        public object Generate()
        {
            return new DateTime(rnd.Next(1, 9999), rnd.Next(1, 12), rnd.Next(1, 27));
        }
    }
}
