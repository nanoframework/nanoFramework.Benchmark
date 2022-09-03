using Microsoft.Extensions.Logging;
using nanoFramework.Benchmark.Attributes;
using System;
using System.Collections;
using System.Reflection;

namespace nanoFramework.Benchmark.Helpers
{
    internal static class ReflectionHelpers
    {
        private static string[] ExcludedMethodsFromBenchmarks =
        {
            "ToString",
            "GetType",
            "GetHashCode"
        };

        internal static object CreateObjectViaReflection(Type typeToCreate)
        {
            // Empty array of Types - GetConstructor didn't work unless given an empty array of Type[]
            Type[] types = { };

            var ci = typeToCreate.GetConstructor(types);

            if (ci == null)
            {
                // failed to create target instance
                return null;
            }

            return ci.Invoke(null);
        }

        internal static object GetSetupMethodIfExists(MethodInfo[] methods)
        {
            foreach (var item in methods)
            {
                if (GetFirstOrDefaultAttribute(item, typeof(SetupAttribute)) != null)
                {
                    return item;
                }
            }

            return null;
        }

        internal static object GetFirstAttribute(MemberInfo member, Type attributeType)
        {
            var attribute = GetFirstOrDefaultAttribute(member, attributeType);
            if (attribute == null)
            {
                throw new InvalidOperationException();
            }

            return attribute;
        }

        internal static object GetFirstOrDefaultAttribute(MemberInfo member, Type attributeType)
        {
            if (attributeType == null)
            {
                throw new ArgumentNullException();
            }

            if (!attributeType.IsSubclassOf(typeof(Attribute)))
            {
                throw new ArgumentException();
            }

            if (member == null)
            {
                throw new ArgumentNullException();
            }

            var attribs = member.GetCustomAttributes(false);
            foreach (var item in attribs)
            {
                var itemType = item.GetType();
                if (itemType == attributeType)
                {
                    return item;
                }

                if (itemType.IsSubclassOf(attributeType))
                {
                    return item;
                }
            }

            return null;
        }

        internal static bool IsMethodProperty(MethodInfo method)
        {
            if (method.ReturnType != null && method.Name.StartsWith("get_"))
            {
                return true;
            }

            if (method.ReturnType == null && method.Name.StartsWith("set_"))
            {
                return true;
            }

            return false;
        }

        private static bool IsMethodExcluded(MethodInfo method)
        {
            if (IsMethodProperty(method))
            {
                return true;
            }

            if (ExcludedMethodsFromBenchmarks.Contains(method.Name))
            {
                return true;
            }

            var setupAttribute = GetFirstOrDefaultAttribute(method, typeof(SetupAttribute));
            if (setupAttribute != null)
            {
                return true;
            }

            return false;
        }

        internal static BenchmarkMethodInfo[] GetBenchmarkMethods(MethodInfo[] methodInfos, ILogger logger)
        {
            var returnList = new ArrayList();
            foreach (var method in methodInfos)
            {
                if (IsMethodExcluded(method))
                {
                    continue;
                }

                var benchmarkAttrib = GetFirstOrDefaultAttribute(method, typeof(BenchmarkAttribute));
                if (benchmarkAttrib == null)
                {
                    continue;
                }

                var parameters = method.GetParameters();
                if (parameters.Length != 0)
                {
                    logger?.LogWarning($"Skippping {method.Name} due to invalid parameters count. Benchmark methods should contains 0 parameters.");
                    continue;
                }

                var isMethodBaseline = CheckIfMethodIsBenchmark(method);
                var benchmarkMethodInfo = new BenchmarkMethodInfo(method, isMethodBaseline);
                returnList.Add(benchmarkMethodInfo);
            }

            return ArrayListHelper.ConvertFromArrayListToBenchmarkMethodInfoArray(returnList);
        }

        private static bool CheckIfMethodIsBenchmark(MethodInfo method)
        {
            var baselineAttrib = GetFirstOrDefaultAttribute(method, typeof(BaselineAttribute));
            if (baselineAttrib == null)
            {
                return false;
            }

            return true;
        }

        internal static object GetObjectInstanceFromPropertyIfExists(object classObject, Type typeToGet)
        {
            var allMethods = classObject.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach (var method in allMethods)
            {
                if (!method.Name.StartsWith("get_"))
                {
                    continue;
                }

                if (method.ReturnType != typeToGet)
                {
                    continue;
                }

                return method.Invoke(classObject, new object[0]);
            }

            return null;
        }

        internal static object GetObjectInstanceFromAttributesIfExists(Type classType, Type typeToGet)
        {
            var attribs = classType.GetCustomAttributes(false);
            foreach (var attrib in attribs)
            {
                var foundObject = GetObjectInstanceFromPropertyIfExists(attrib, typeToGet);
                if (foundObject != null)
                {
                    return foundObject;
                }
            }

            return null;
        }

        internal static ArrayList GetObjectsInstanceFromAttributesIfExists(Type classType, Type typeToGet)
        {
            var attribs = classType.GetCustomAttributes(false);
            var returnList = new ArrayList();
            foreach (var attrib in attribs)
            {
                var foundObject = GetObjectInstanceFromPropertyIfExists(attrib, typeToGet);
                if (foundObject != null)
                {
                    returnList.Add(foundObject);
                }
            }

            return returnList;
        }
    }
}
