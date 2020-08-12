using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(clothes);

            int sum = 0;
            int racksCount = 1;
            int lastPopped = 0;

            while (stack.Count > 0)
            {
                while (sum < capacity && stack.Count > 0)
                {
                    lastPopped = stack.Peek();
                    sum += stack.Pop();
                }
                if (sum == capacity && stack.Count > 0)
                {
                    racksCount++;
                    sum = 0;
                }
                if (sum > capacity)
                {
                    racksCount++;
                    stack.Push(lastPopped);
                    sum = 0;
                }
            }

            Console.WriteLine(racksCount);
        }
    }
}
