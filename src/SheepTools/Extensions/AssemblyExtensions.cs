using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SheepTools.Extensions
{
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Returns types marked with TAttribute within its assembly
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Type> GetTypes<TAttribute>()
            where TAttribute : Attribute
        {
            return GetTypes<TAttribute>(Assembly.GetAssembly(typeof(TAttribute)));
        }

        /// <summary>
        /// Returns types marked with TAttribute within a given assembly
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetTypes<TAttribute>(this Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsDefined(typeof(TAttribute), true))
                {
                    yield return type;
                }
            }
        }

        /// <summary>
        /// Returns types marked with TAttribute and TAttribute value within its assembly
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static IEnumerable<Tuple<Type, TAttribute>> GetTypesAndAttributes<TAttribute>()
            where TAttribute : Attribute
        {
            return GetTypesAndAttributes<TAttribute>(Assembly.GetAssembly(typeof(TAttribute)));
        }

        /// <summary>
        /// Returns types marked with TAttribute and TAttribute value within a given assembly
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IEnumerable<Tuple<Type, TAttribute>> GetTypesAndAttributes<TAttribute>(this Assembly assembly)
            where TAttribute : Attribute
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsDefined(typeof(TAttribute), true))
                {
                    foreach (TAttribute attribute in type.GetCustomAttributes<TAttribute>())
                    {
                        yield return Tuple.Create(type, attribute);
                    }
                }
            }
        }

        /// <summary>
        /// Returns list of assembly names containing type/types implementing T
        /// Method searches in Entry assembly and all its referenced ones
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>string Collection</returns>
        public static IEnumerable<string> GetAssemblies<T>()
        {
            IList<string> validAssemblies = new List<string>();
            IList<AssemblyName> assemblies = new List<AssemblyName>();
            assemblies.AddRange(Assembly.GetCallingAssembly().GetReferencedAssemblies());
            assemblies.Add(Assembly.GetCallingAssembly().GetName());
            foreach (var assemblyName in assemblies)
            {
                var candidate = Assembly.Load(assemblyName);
                foreach (var ti in candidate.DefinedTypes)
                {
                    if (ti.ImplementedInterfaces.Contains(typeof(T)))
                    {
                        validAssemblies.Add(candidate.GetName().Name);
                    }
                }
            }
            return validAssemblies;
        }
    }
}
