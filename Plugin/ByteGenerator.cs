using InterfacesLib;

namespace Plugin
{
    class ByteGenerator : IGenerator<byte>
    {
        public byte Generate()
        {
            byte i = 1;

            return i;
        }
    }
}
