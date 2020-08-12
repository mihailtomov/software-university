using System;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            string repeatedWord = StringRepeatedCountTimes(word, count);
            Console.WriteLine(repeatedWord);
        }

        static string StringRepeatedCountTimes(string input, int n)
        {
            string result = "";

            for (int i = 0; i < n; i++)
            {
                result += input;
            }

            return result;
        }
    }
}
