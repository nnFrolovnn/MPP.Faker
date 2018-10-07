using InterfacesLib;
using System;
using System.IO;
using System.Reflection;


namespace FakerApp
{
    class DllLoader
    {
        public IPlugin Load(string pathDll)
        {
            if (File.Exists(pathDll))
            {
                var asm = Assembly.LoadFrom(pathDll);
                foreach (var type in asm.GetTypes())
                {
                    if (type.GetInterface("IPlugin") != null)
                    {
                        return (IPlugin)Activator.CreateInstance(type);
                    }
                }
            }
            return null;
        }
    }
}
