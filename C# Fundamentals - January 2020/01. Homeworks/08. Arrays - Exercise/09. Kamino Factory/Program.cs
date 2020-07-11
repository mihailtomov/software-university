using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequenceLength = int.Parse(Console.ReadLine());

            string currSequence = Console.ReadLine();
            int[] bestSequence = new int[sequenceLength];

            int bestSum = 0;
            int bestSample = 0;
            int currentSample = 0;
            int bestCount = 0;
            int bestIndex = 0;

            while (currSequence != "Clone them!")
            {
                int[] splitted = currSequence.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int currentSum = 0;
                currentSample++;

                for (int i = 0; i < splitted.Length; i++)
                {
                    currentSum += splitted[i];
                }

                int currCount = 1;
                int currBestIndex = 0;

                for (int i = 0; i < splitted.Length; i++)
                {
                    int currElement = splitted[i];

                    if (currElement == 1)
                    {
                        for (int j = i + 1; j < splitted.Length - 1; j++)
                        {
                            if (currElement == splitted[j])
                            {
                                currCount++;
                                currBestIndex = i;
                            }

                            else
                            {
                                break;
                            }
                        }
                    }                   
                }

                if (currCount > bestCount || currentSum > bestSum || currBestIndex < bestIndex)
                {
                    bestCount = currCount;
                    bestIndex = currBestIndex;
                    bestSum = currentSum;
                    bestSample = currentSample;
                    bestSequence = splitted;
                }

                currSequence = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestSequence));
        }
    }
}