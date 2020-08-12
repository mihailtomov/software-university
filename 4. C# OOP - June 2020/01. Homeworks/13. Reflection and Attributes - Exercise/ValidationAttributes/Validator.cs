using System;
using System.Collections.Generic;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] objProperties = objType.GetProperties();

            foreach (PropertyInfo property in objProperties)
            {
                IEnumerable<MyValidationAttribute> myAttributes = property.GetCustomAttributes<MyValidationAttribute>();

                object propertyValue = property.GetValue(obj);

                foreach (var attribute in myAttributes)
                {
                    bool isValid = attribute.IsValid(propertyValue);

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
