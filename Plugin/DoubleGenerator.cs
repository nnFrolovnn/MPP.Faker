using InterfacesLib;

namespace Plugin
{
    class DoubleGenerator : IGenerator
    {
        public object Generate()
        {
            double i = 5.7;

            return i;
        }
    }
}
