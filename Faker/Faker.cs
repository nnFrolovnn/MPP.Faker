using InterfacesLib;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class Faker
    {
        readonly ConcurrentDictionary<Type, IGenerator> registredTypes;
        readonly Stack<Type> usedTypes;
        object locker; 

        public Faker(ConcurrentDictionary<Type, IGenerator> dictionary)
        {
            registredTypes = dictionary;
            usedTypes = new Stack<Type>();
            locker = new object();
        }

        public T Create<T>() where T : new()
        {
            var constructors = (typeof(T).GetConstructors().OrderBy(x => x.GetParameters().Length)).ToArray();
            
            bool isCreated = false;
            int constructorNumber = 1;
            T result = default(T);

            while (!isCreated && constructorNumber <= constructors.Count())
            {
                try
                {
                    var useConstructor = constructors[constructorNumber - 1];
                    result = CreatefromConstructor<T>(useConstructor);
                    isCreated = true;
                }
                catch
                {
                    isCreated = false;
                    constructorNumber++;
                }
            }
            
            if (isCreated)
            {
                FillProperties(ref result);

                return result;
            }
            else
            {
                throw new Exception("can't create object (Type: " + typeof(T).FullName + ")");
            }
        }

        private T CreatefromConstructor<T>(ConstructorInfo constructor)
        {
            var parametersInfo = constructor.GetParameters();
            var parameters = new object[parametersInfo.Length];

            for (int i = 0; i < parametersInfo.Length; i++)
            {
                parameters[i] = GetValue(parametersInfo[i].ParameterType);
            }

            return (T)constructor.Invoke(parameters);
        }

        private void FillProperties<T>(ref T result)
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                if (property?.SetMethod != null)
                {
                    if (property.SetMethod.IsPublic)
                    {
                        SetProperty(ref result, property);

                        //property.SetMethod.Invoke(result, new[] {GetValue(property.PropertyType)});
                    }
                }
            }
        }

        private object GetValue(Type type)
        {
            try
            {
                if (registredTypes.ContainsKey(type))
                {
                    var value = registredTypes[type].Generate();
                    return value;
                }
                else
                {
                    return new object();
                }
            }
            catch
            {
                throw new Exception("unable to get value");
            }
        }

        private void SetProperty<T>(ref T result, PropertyInfo property)
        {
            Type propertyType = property.PropertyType;
            string objectType = result.GetType().Name;
            object[] set = new object[1];

            if (registredTypes.ContainsKey(propertyType))
            {
                set = new object[] { registredTypes[propertyType].Generate() };            
            }
            else
            {
                set = new object[] { GetDTO(ref result, propertyType) };
            }

            property.SetMethod.Invoke(result, set);

        }


        private object GetDTO<T>(ref T result, Type property)
        {
            try
            {
                MethodInfo method = typeof(Faker).GetMethod("Create", BindingFlags.Public);
                MethodInfo genericMethod = method?.MakeGenericMethod();
                var dto = genericMethod?.Invoke(this, new object[] { result });
                return dto;
            }
            catch
            {
                return null;
            }  
        }
    }
}
