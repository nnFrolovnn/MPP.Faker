using InterfacesLib;
using System;

namespace Plugin
{
    class DateTimeGenerator : IGenerator
    {
        public object Generate()
        {
            DateTime dateTime = new DateTime(1, 1, 1, 1, 1, 1);

            return dateTime;
        }
    }
}
