using InterfacesLib;

namespace Plugin
{
    class CharGenerator : IGenerator<char>
    {
        public char Generate()
        {
            char i = 'a';

            return i;
        }
    }
}
