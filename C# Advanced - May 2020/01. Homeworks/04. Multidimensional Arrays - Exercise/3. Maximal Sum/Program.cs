using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = nums[cols];
                }
            }

            int row = -1;
            int col = -1;
            int maxSum = int.MinValue;

            for (int rows = 0; rows < matrix.GetLength(0) - 2; rows++)
            {             
                for (int cols = 0; cols < matrix.GetLength(1) - 2; cols++)
                {
                    int sum = 
                        matrix[rows, cols] + matrix[rows, cols + 1] + matrix[rows, cols + 2]
                        + matrix[rows + 1, cols] + matrix[rows + 1, cols + 1] + matrix[rows + 1, cols + 2] 
                        + matrix[rows + 2, cols] + matrix[rows + 2, cols + 1] + matrix[rows + 2, cols + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        row = rows;
                        col = cols;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[row, col]} {matrix[row, col + 1]} {matrix[row, col + 2]}");
            Console.WriteLine($"{matrix[row + 1, col]} {matrix[row + 1, col + 1]} {matrix[row + 1, col + 2]}");
            Console.WriteLine($"{matrix[row + 2, col]} {matrix[row + 2, col + 1]} {matrix[row + 2, col + 2]}");
        }
    }
}
