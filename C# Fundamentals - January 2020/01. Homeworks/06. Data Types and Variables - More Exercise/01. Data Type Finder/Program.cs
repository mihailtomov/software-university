using System;

namespace _01._Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int isInteger;
            double isDouble;
            bool isBool;
            char isChar;

            while (input != "END")
            {
                if (int.TryParse(input, out isInteger))
                {
                    Console.WriteLine($"{input} is integer type");
                }

                else if (double.TryParse(input, out isDouble))
                {
                    Console.WriteLine($"{input} is floating point type");
                }

                else if (bool.TryParse(input, out isBool))
                {
                    Console.WriteLine($"{input} is boolean type");
                }

                else if (char.TryParse(input, out isChar))
                {
                    Console.WriteLine($"{input} is character type");
                }

                else
                {
                    Console.WriteLine($"{input} is string type");
                }

                input = Console.ReadLine();
            }
        }
    }
}
