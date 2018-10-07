using InterfacesLib;

namespace Plugin
{
    class FloatGenerator : IGenerator<float>
    {
        public float Generate()
        {
            float i = 4.5F;

            return i;
        }
    }
}
