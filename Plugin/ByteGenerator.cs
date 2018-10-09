using InterfacesLib;

namespace Plugin
{
    class ByteGenerator : IGenerator
    {
        public object Generate()
        {
            byte i = 123;

            return i;
        }
    }
}
