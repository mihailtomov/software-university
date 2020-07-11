using System;
using System.Linq;

namespace _02._Shoot_for_the_Win
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int shotTargetsCount = 0;
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                int currIndex = int.Parse(input);

                if (currIndex >= 0 && currIndex < targets.Length)
                {
                    int currValue = targets[currIndex];

                    if (targets[currIndex] != -1)
                    {
                        targets[currIndex] = -1;
                        shotTargetsCount++;

                        for (int i = 0; i < targets.Length; i++)
                        {
                            if (targets[i] > currValue)
                            {
                                targets[i] -= currValue;
                            }
                            else if (targets[i] <= currValue && targets[i] != -1)
                            {
                                targets[i] += currValue;
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Shot targets: {shotTargetsCount} -> {string.Join(" ", targets)}");
        }
    }
}
