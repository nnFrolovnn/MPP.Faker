using InterfacesLib;

namespace Plugin
{
    class ByteGenerator : IGenerator
    {
        public object Generate()
        {
            byte i = 1;

            return i;
        }
    }
}
