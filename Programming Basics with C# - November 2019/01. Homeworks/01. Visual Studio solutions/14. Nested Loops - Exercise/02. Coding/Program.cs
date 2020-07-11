using System;

namespace _02._Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                int current = int.Parse(input[i].ToString());

                if (current == 0)
                {
                    Console.WriteLine("ZERO");
                    continue;
                }
                
                for (int j = 1; j <= current; j++)
                {
                    Console.Write((char)(current + 33));
                }

                Console.WriteLine();
            }
        }
    }
}
