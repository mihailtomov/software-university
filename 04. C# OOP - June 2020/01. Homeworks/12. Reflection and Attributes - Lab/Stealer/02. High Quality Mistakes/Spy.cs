using System;
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
    }
}
