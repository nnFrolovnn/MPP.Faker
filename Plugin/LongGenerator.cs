using InterfacesLib;

namespace Plugin
{
    class LongGenerator : IGenerator<long>
    {
        public long Generate()
        {
            long i = 9;

            return i;
        }
    }
}
