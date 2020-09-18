using System;

namespace _10._Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int inputCharNum = input[0];

            if (inputCharNum >= 97 && inputCharNum <= 122)
            {
                Console.WriteLine("lower-case");
            }

            else
            {
                Console.WriteLine("upper-case");
            }
        }
    }
}
