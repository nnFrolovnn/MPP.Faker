using InterfacesLib;
using System;

namespace Plugin
{
    class DateTimeGenerator : IGenerator<DateTime>
    {
        public DateTime Generate()
        {
            DateTime dateTime = new DateTime(2000, 12, 1, 14, 24, 14);

            return dateTime;
        }
    }
}
