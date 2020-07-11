using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            bool toPrintList = false;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] splitCommand = command.Split();

                IfContains(nums, splitCommand);
                IfPrintEven(nums, splitCommand);
                IfPrintOdd(nums, splitCommand);
                IfGetSum(nums, splitCommand);
                IfFilter(nums, splitCommand);
                OriginalCommands(nums, splitCommand);

                if (splitCommand[0] == "Add" || splitCommand[0] == "Remove" || splitCommand[0] == "RemoveAt" || splitCommand[0] == "Insert")
                {
                    toPrintList = true;
                }
            } 

            if (toPrintList)
            {
                Console.WriteLine(string.Join(" ", nums));
            }
        }

        private static void OriginalCommands(List<int> nums, string[] splitCommand)
        {
            if (splitCommand[0] == "Add")
            {
                nums.Add(int.Parse(splitCommand[1]));
            }

            if (splitCommand[0] == "Remove")
            {
                nums.Remove(int.Parse(splitCommand[1]));
            }

            if (splitCommand[0] == "RemoveAt")
            {
                nums.RemoveAt(int.Parse(splitCommand[1]));
            }

            if (splitCommand[0] == "Insert")
            {
                nums.Insert(int.Parse(splitCommand[2]), int.Parse(splitCommand[1]));
            }
        }

        private static void IfFilter(List<int> nums, string[] splitCommand)
        {
            if (splitCommand[0] == "Filter")
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    if (splitCommand[1] == "<" && nums[i] < int.Parse(splitCommand[2]))
                    {
                        Console.Write(nums[i] + " ");
                    }
                    if (splitCommand[1] == ">" && nums[i] > int.Parse(splitCommand[2]))
                    {
                        Console.Write(nums[i] + " ");
                    }
                    if (splitCommand[1] == ">=" && nums[i] >= int.Parse(splitCommand[2]))
                    {
                        Console.Write(nums[i] + " ");
                    }
                    if (splitCommand[1] == "<=" && nums[i] <= int.Parse(splitCommand[2]))
                    {
                        Console.Write(nums[i] + " ");
                    }
                }

                Console.WriteLine();
            }
        }

        private static void IfGetSum(List<int> nums, string[] splitCommand)
        {
            int totalSum = 0;

            for (int i = 0; i < nums.Count; i++)
            {
                totalSum += nums[i];
            }

            if (splitCommand[0] == "GetSum")
            {
                Console.WriteLine(totalSum);
            }
        }

        private static void IfPrintOdd(List<int> nums, string[] splitCommand)
        {
            if (splitCommand[0] == "PrintOdd")
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    if (nums[i] % 2 != 0)
                    {
                        Console.Write(nums[i] + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void IfPrintEven(List<int> nums, string[] splitCommand)
        {
            if (splitCommand[0] == "PrintEven")
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    if (nums[i] % 2 == 0)
                    {
                        Console.Write(nums[i] + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void IfContains(List<int> nums, string[] splitCommand)
        {
            if (splitCommand[0] == "Contains")
            {
                bool isContained = false;

                for (int i = 0; i < nums.Count; i++)
                {
                    if (nums[i] == int.Parse(splitCommand[1]))
                    {
                        isContained = true;
                        break;
                    }
                }

                if (isContained)
                {
                    Console.WriteLine("Yes");
                }

                else
                {
                    Console.WriteLine("No such number");
                }
            }
        }
    }
}
