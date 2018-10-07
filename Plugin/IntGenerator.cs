using InterfacesLib;

namespace Plugin
{
    class IntGenerator : IGenerator<int>
    {
        public int Generate()
        {
            int i = 9;

            return i;
        }
    }
}
