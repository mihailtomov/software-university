using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] nums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = nums[cols];
                }
            }

            int biggestSum = int.MinValue;
            int row = -1;
            int col = -1;

            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
                {
                    int currSum = matrix[rows, cols] + matrix[rows, cols + 1] + matrix[rows + 1, cols] + matrix[rows + 1, cols + 1];

                    if (currSum > biggestSum)
                    {
                        biggestSum = currSum;
                        row = rows;
                        col = cols;
                    }
                }
            }

            Console.WriteLine($"{matrix[row, col]} {matrix[row, col + 1]}");
            Console.WriteLine($"{matrix[row + 1, col]} {matrix[row + 1, col + 1]}");
            Console.WriteLine(biggestSum);
        }
    }
}
