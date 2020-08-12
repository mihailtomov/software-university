using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        private readonly StringBuilder result;

        public Spy()
        {
            result = new StringBuilder();
        }

        public string StealFieldInfo(string className, params string[] fieldNames)
        {
            Type type = Type.GetType(className);

            result.AppendLine($"Class under investigation: {className}");
            FieldInfo fieldInfo = null;
            var investigatedClass = Activator.CreateInstance(type);

            foreach (string fieldName in fieldNames)
            {
                fieldInfo = type.GetField(fieldName,
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                string name = fieldInfo.Name;
                var value = fieldInfo.GetValue(investigatedClass);
                result.AppendLine($"{name} = {value}");
            }

            return result.ToString().Trim();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            Type type = Type.GetType(className);

            FieldInfo[] fields = type.GetFields
                (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] methods = type.GetMethods
                (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            foreach (var field in fields)
            {
                if (field.IsPublic)
                {
                    result.AppendLine($"{field.Name} must be private!");
                }
            }

            foreach (var method in methods)
            {
                if (method.Name.Contains("get") && method.IsPrivate)
                {
                    result.AppendLine($"{method.Name} have to be public!");
                }
                if (method.Name.Contains("set") && method.IsPublic)
                {
                    result.AppendLine($"{method.Name} have to be private!");
                }
            }

            return result.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);
            result.AppendLine($"All Private Methods of Class: {type.FullName}");
            result.AppendLine($"Base Class: {type.BaseType.Name}");
            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var method in methods)
            {
                result.AppendLine(method.Name);
            }

            return result.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type type = Type.GetType(className);
            MethodInfo[] methods = type.GetMethods
                (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] getters = methods.Where(m => m.Name.Contains("get")).ToArray();
            MethodInfo[] setters = methods.Where(m => m.Name.Contains("set")).ToArray();
            AppendMethodsInfoToResult(getters);
            AppendMethodsInfoToResult(setters);

            return result.ToString().Trim();
        }

        private void AppendMethodsInfoToResult(MethodInfo[] methods)
        {
            foreach (var method in methods)
            {
                if (method.Name.Contains("get"))
                {
                    result.AppendLine($"{method.Name} will return {method.ReturnType}");
                }
                else
                {
                    result.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
                }
            }
        }
    }
}
