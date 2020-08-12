using System;

namespace _05._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int n = 1; n <= count; n++)
            {
                int num = int.Parse(Console.ReadLine());
                sum = sum + num;
            }

            Console.WriteLine(sum);
        }
    }
}
