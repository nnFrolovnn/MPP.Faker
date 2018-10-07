using InterfacesLib;

namespace Plugin
{
    class LongGenerator : IGenerator
    {
        public object Generate()
        {
            long i = 9;

            return i;
        }
    }
}
