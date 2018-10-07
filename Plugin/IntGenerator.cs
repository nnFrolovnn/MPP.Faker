using InterfacesLib;

namespace Plugin
{
    class IntGenerator : IGenerator
    {
        public object Generate()
        {
            int i = 9;

            return i;
        }
    }
}
