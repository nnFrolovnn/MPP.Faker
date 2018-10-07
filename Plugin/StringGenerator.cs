using InterfacesLib;

namespace Plugin
{
    class StringGenerator : IGenerator<string>
    {
        public string Generate()
        {
            return "rerere";
        }
    }
}
