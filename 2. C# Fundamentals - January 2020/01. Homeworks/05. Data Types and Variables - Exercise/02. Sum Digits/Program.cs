using System;

namespace _02._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int integer = int.Parse(Console.ReadLine());
            string integerLength = integer.ToString();
            int sum = 0;

            for (int i = 0; i < integerLength.Length; i++)
            {
                sum += integer % 10;
                integer = integer / 10;
            }

            Console.WriteLine(sum);
        }
    }
}
