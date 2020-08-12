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

            if (type != null)
            {
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
            }

            return result.ToString().Trim();
        }
    }
}
