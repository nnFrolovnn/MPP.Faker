using InterfacesLib;
using System;
using System.Text;

namespace RandomPlugin
{
    class StringGenerator : IGenerator
    {
        Random rnd = new Random((int)DateTime.Now.Ticks);

        public object Generate()
        {
            int length = rnd.Next(5, 25);

            StringBuilder str = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                str.Append((char)rnd.Next(65, 91), 1);
            }


            return str.ToString();
        }
    }
}
