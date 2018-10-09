using InterfacesLib;

namespace Plugin
{
    class DoubleGenerator : IGenerator
    {
        public object Generate()
        {
            double i = 456.2;

            return i;
        }
    }
}
