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
        #region Fields
        readonly ConcurrentDictionary<Type, IGenerator> registredTypes;
        readonly ConcurrentDictionary<Type, int> currentrecursionLevel;
        int maxRecursionLevel;
        object locker;

        #endregion

        public Faker(ConcurrentDictionary<Type, IGenerator> dictionary)
        {
            registredTypes = dictionary;
            locker = new object();
            maxRecursionLevel = 2;
            currentrecursionLevel = new ConcurrentDictionary<Type, int>();
        }

        public Faker(ConcurrentDictionary<Type, IGenerator> dictionary, int recursionLevel)
        {
            registredTypes = dictionary;
            locker = new object();
            maxRecursionLevel = recursionLevel;
            currentrecursionLevel = new ConcurrentDictionary<Type, int>();
        }

        #region Recursion Dictionary

        public bool HaveToCreate(Type type)
        {
            if (currentrecursionLevel.ContainsKey(type))
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

        public void AddToDict(Type type)
        {
            if (currentrecursionLevel.ContainsKey(type))
            {
                currentrecursionLevel[type] += 1;
            }
            else
            {
                currentrecursionLevel.TryAdd(type, 1);
            }
        }

        public void RetrieveFromDict(Type type)
        {
            if (currentrecursionLevel.ContainsKey(type))
            { 
                currentrecursionLevel[type] -= 1;
                if (currentrecursionLevel[type] < 1)
                {
                    currentrecursionLevel.TryRemove(type, out int i);
                }
            }
        }

        #endregion 

        public T Create<T>() where T : new()
        {
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
                if (HaveToCreate(type))
                {
                    AddToDict(type);

                    MethodInfo method = typeof(Faker).GetMethod("Create");
                    MethodInfo genericMethod = method?.MakeGenericMethod(type);
                    var dto = genericMethod?.Invoke(this, null);

                    RetrieveFromDict(type);

                    return dto;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                RetrieveFromDict(type);
                return null;
            }
        }
    }
}
