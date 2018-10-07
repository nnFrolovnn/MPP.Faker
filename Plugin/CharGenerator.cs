using InterfacesLib;

namespace Plugin
{
    class CharGenerator : IGenerator
    {
        public object Generate()
        {
            char i = 'a';

            return i;
        }
    }
}
