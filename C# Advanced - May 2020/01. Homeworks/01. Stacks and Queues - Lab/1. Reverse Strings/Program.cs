using System;
using System.Collections.Generic;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> reversedString = new Stack<char>(input);

            foreach (var letter in reversedString)
            {
                Console.Write(letter);
            }
        }
    }
}
