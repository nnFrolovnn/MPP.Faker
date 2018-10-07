using InterfacesLib;

namespace Plugin
{
    class BoolGenerator : IGenerator<bool>
    {
        bool IGenerator<bool>.Generate()
        {
            return true;
        }
    }
}
