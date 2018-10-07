using InterfacesLib;

namespace Plugin
{
    class FloatGenerator : IGenerator
    {
        public object Generate()
        {
            float i = 4.5F;

            return i;
        }
    }
}
