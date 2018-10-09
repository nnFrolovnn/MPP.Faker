using InterfacesLib;

namespace Plugin
{
    class FloatGenerator : IGenerator
    {
        public object Generate()
        {
            float i = 45.2F;

            return i;
        }
    }
}
