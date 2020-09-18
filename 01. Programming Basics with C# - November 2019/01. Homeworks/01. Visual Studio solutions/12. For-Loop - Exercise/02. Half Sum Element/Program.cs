using System;

namespace _02._Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCount = int.Parse(Console.ReadLine());
            int total = 0;
            int max = int.MinValue;

            for (int i = 0; i < numCount; i++)
            {
                int newNum = int.Parse(Console.ReadLine());
                total += newNum;

                if (newNum > max)
                {
                    max = newNum;
                }
            }

            int totalWithoutMaxNumber = total - max;

            if (max == totalWithoutMaxNumber)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = " + max);
            }

            else
            {
                int diff = Math.Abs(max - totalWithoutMaxNumber);
                Console.WriteLine("No");
                Console.WriteLine("Diff = " + diff);
            }
        }
    }
}
