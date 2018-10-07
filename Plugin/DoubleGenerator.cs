using InterfacesLib;

namespace Plugin
{
    class DoubleGenerator : IGenerator<double>
    {
        public double Generate()
        {
            double i = 5.7;

            return i;
        }
    }
}
