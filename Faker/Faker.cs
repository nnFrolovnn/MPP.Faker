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
        readonly ConcurrentDictionary<Type, int> currentrecursionLevel;
        int maxRecursionLevel;
        readonly Stack<Type> usedTypes;
        object locker;

        public Faker(ConcurrentDictionary<Type, IGenerator> dictionary)
        {
            registredTypes = dictionary;
            usedTypes = new Stack<Type>();
            locker = new object();
            maxRecursionLevel = 1;
            currentrecursionLevel = new ConcurrentDictionary<Type, int>();
        }

        public Faker(ConcurrentDictionary<Type, IGenerator> dictionary, int recursionLevel)
        {
            registredTypes = dictionary;
            usedTypes = new Stack<Type>();
            locker = new object();
            maxRecursionLevel = recursionLevel;
            currentrecursionLevel = new ConcurrentDictionary<Type, int>();
        }

        public T Create<T>() where T : new()
        {
            //TODO stack
            var constructors = (typeof(T).GetConstructors().OrderByDescending(x => x.GetParameters().Length)).ToArray();

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

        public bool HaveToCreate(Type type)
        {
            if (usedTypes.Count == 0)
            {
                return true;
            }
            else if (usedTypes.Contains(type))
            {
                if (currentrecursionLevel[type] < maxRecursionLevel)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public void AddToStack(Type type)
        {
            //TODO
            if(usedTypes.Contains(type))
            {
                currentrecursionLevel[type] += 1;
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
                    return GetDTO(type);
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
                set = new object[] { GetDTO(propertyType) };
            }

            property.SetMethod.Invoke(result, set);

        }


        private object GetDTO(Type type)
        {
            try
            {
                MethodInfo method = typeof(Faker).GetMethod("Create");
                MethodInfo genericMethod = method?.MakeGenericMethod(type);
                var dto = genericMethod?.Invoke(this, null);
                return dto;
            }
            catch
            {
                return null;
            }
        }
    }
}
