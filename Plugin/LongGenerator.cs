using InterfacesLib;

namespace Plugin
{
    class LongGenerator : IGenerator
    {
        public object Generate()
        {
            long i = 1234567890;

            return i;
        }
    }
}
