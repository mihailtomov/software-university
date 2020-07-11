using System;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string firstValue = Console.ReadLine();
            string secondValue = Console.ReadLine();

            string result = GetMax(type, firstValue, secondValue);
            Console.WriteLine(result);
        }

        static string GetMax(string type, string v1, string v2)
        {
            if (type == "int")
            {
                if (int.Parse(v1) > int.Parse(v2))
                {
                    return v1;
                }
                else
                {
                    return v2;
                }
            }
            else if (type == "char")
            {
                if (Char.Parse(v1) > Char.Parse(v2))
                {
                    return v1;
                }
                else
                {
                    return v2;
                }
            }
            else if (type == "string")
            {
                if (v1.CompareTo(v2) > 0)
                {
                    return v1;
                }
                else
                {
                    return v2;
                }
            }
            else
            {
                return "";
            }
        }
    }
}
