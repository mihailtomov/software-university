using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] bombinfo = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int bombNumber = bombinfo[0];
            int power = bombinfo[1];

            while (true)
            {
                int indexOfBomb = numbers.IndexOf(bombNumber);
                int numbersCount = numbers.Count;

                if (indexOfBomb == -1)
                {
                    break;
                }

                int rightIndex = indexOfBomb + power;

                for (int i = indexOfBomb; i <= rightIndex; i++)
                {
                    if (i < numbersCount)
                    {
                        numbers.RemoveAt(indexOfBomb);
                    }

                    else
                    {
                        break;
                    }
                }

                int leftIndex = indexOfBomb - power;

                for (int i = indexOfBomb - 1; i >= leftIndex; i--)
                {
                    if (i >= 0)
                    {
                        numbers.RemoveAt(i);
                    }

                    else
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
