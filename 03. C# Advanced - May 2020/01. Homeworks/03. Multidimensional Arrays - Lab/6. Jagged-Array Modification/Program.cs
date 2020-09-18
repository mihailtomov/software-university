using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jagged = new int[rows][];

            for (int row = 0; row < jagged.Length; row++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jagged[row] = nums;
            }

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] splitArgs = command.Split();

                if (splitArgs[0] == "Add")
                {
                    int row = int.Parse(splitArgs[1]);
                    int col = int.Parse(splitArgs[2]);
                    int value = int.Parse(splitArgs[3]);

                    if ((row >= 0 && row < jagged.Length) && (col >= 0 && col < jagged[row].Length))
                    {
                        jagged[row][col] += value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                if (splitArgs[0] == "Subtract")
                {
                    int row = int.Parse(splitArgs[1]);
                    int col = int.Parse(splitArgs[2]);
                    int value = int.Parse(splitArgs[3]);

                    if ((row >= 0 && row < jagged.Length) && (col >= 0 && col < jagged[row].Length))
                    {
                        jagged[row][col] -= value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
            }

            foreach (int[] arr in jagged)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
