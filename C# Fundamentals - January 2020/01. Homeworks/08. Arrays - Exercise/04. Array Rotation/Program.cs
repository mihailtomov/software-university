using System;
using System.Linq;

namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            int count = int.Parse(Console.ReadLine());     

            for (int c = 0; c < count; c++)
            {
                string temp = numbers[0];

                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    numbers[i] = numbers[i + 1];
                }

                numbers[numbers.Length - 1] = temp;
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
