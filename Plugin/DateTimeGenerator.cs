using InterfacesLib;
using System;

namespace Plugin
{
    class DateTimeGenerator : IGenerator
    {
        public object Generate()
        {
            DateTime dateTime = new DateTime(2000, 12, 1, 14, 24, 14);

            return dateTime;
        }
    }
}
