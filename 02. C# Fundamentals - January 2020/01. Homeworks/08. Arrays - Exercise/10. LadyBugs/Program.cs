using System;
using System.Linq;

namespace _10._LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] bugsIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] ladybugs = new int[fieldSize];

            for (int i = 0; i < bugsIndexes.Length; i++)
            {
                ladybugs[bugsIndexes[i]] = 1;
            }

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] splitted = command.Split();

                if (splitted[1] == "left")
                {
                    int index = int.Parse(splitted[0]);
                    int flyLength = int.Parse(splitted[2]);
                    int moveLeft = index - flyLength;

                    if (index - flyLength >= 0 && index - flyLength < ladybugs.Length)
                    {
                        if (ladybugs[index] > 0)
                        {
                            while (moveLeft >= 0)
                            {
                                if (ladybugs[moveLeft] != 0)
                                {
                                    moveLeft -= flyLength;
                                }
                                else
                                {
                                    int temp = ladybugs[index];
                                    ladybugs[moveLeft] = temp;
                                    ladybugs[index] = 0;
                                    break;
                                }
                            }
                        }
                    }

                    if (moveLeft < 0)
                    {
                        ladybugs[index] = 0;
                    }
                }

                if (splitted[1] == "right")
                {
                    int index = int.Parse(splitted[0]);
                    int flyLength = int.Parse(splitted[2]);
                    int moveRight = index + flyLength;

                    if (index + flyLength >= 0 && index + flyLength < ladybugs.Length)
                    {
                        if (ladybugs[index] > 0)
                        {
                            while (moveRight < ladybugs.Length)
                            {
                                if (ladybugs[moveRight] != 0)
                                {
                                    moveRight += flyLength;
                                }
                                else
                                {
                                    int temp = ladybugs[index];
                                    ladybugs[moveRight] = temp;
                                    ladybugs[index] = 0;
                                    break;
                                }
                            }
                        }
                    }

                    if (moveRight > ladybugs.Length - 1)
                    {
                        ladybugs[index] = 0;
                    }
                }


                command = Console.ReadLine();
            }

            for (int i = 0; i < ladybugs.Length; i++)
            {
                if (ladybugs[i] > 0)
                {
                    ladybugs[i] = 1;
                }

                else if (ladybugs[i] < 0)
                {
                    ladybugs[i] = 0;
                }
            }

            Console.WriteLine(string.Join(" ", ladybugs));
        }
    }
}
