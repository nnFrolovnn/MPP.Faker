using InterfacesLib;

namespace Plugin
{
    class IntGenerator : IGenerator
    {
        public object Generate()
        {
            int i = 12345;

            return i;
        }
    }
}
