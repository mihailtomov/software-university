using System;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int rows = 0; rows < size; rows++)
            {
                int[] nums = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int cols = 0; cols < size; cols++)
                {
                    matrix[rows, cols] = nums[cols];
                }
            }

            string[] bombs = Console.ReadLine().Split();

            for (int i = 0; i < bombs.Length; i++)
            {
                string[] tokens = bombs[i].Split(",");
                int row = int.Parse(tokens[0]);
                int col = int.Parse(tokens[1]);
                int bomb = matrix[row, col];

                if (matrix[row, col] > 0)
                {
                    if (row - 1 >= 0 && matrix[row - 1, col] > 0)
                    {
                        matrix[row - 1, col] -= bomb;
                    }
                    if (row + 1 < size && matrix[row + 1, col] > 0)
                    {
                        matrix[row + 1, col] -= bomb;
                    }
                    if (row - 1 >= 0 && col - 1 >= 0 && matrix[row - 1, col - 1] > 0)
                    {
                        matrix[row - 1, col - 1] -= bomb;
                    }
                    if (row - 1 >= 0 && col + 1 < size && matrix[row - 1, col + 1] > 0)
                    {
                        matrix[row - 1, col + 1] -= bomb;
                    }
                    if (col - 1 >= 0 && matrix[row, col - 1] > 0)
                    {
                        matrix[row, col - 1] -= bomb;
                    }
                    if (col + 1 < size && matrix[row, col + 1] > 0)
                    {
                        matrix[row, col + 1] -= bomb;
                    }
                    if (row + 1 < size && col - 1 >= 0 && matrix[row + 1, col - 1] > 0)
                    {
                        matrix[row + 1, col - 1] -= bomb;
                    }
                    if (row + 1 < size && col + 1 < size && matrix[row + 1, col + 1] > 0)
                    {
                        matrix[row + 1, col + 1] -= bomb;
                    }

                    matrix[row, col] = 0;
                }
            }

            int aliveCells = 0;
            int sumOfCells = 0;

            for (int rows = 0; rows < size; rows++)
            {
                for (int cols = 0; cols < size; cols++)
                {
                    if (matrix[rows, cols] > 0)
                    {
                        aliveCells++;
                        sumOfCells += matrix[rows, cols];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumOfCells}");

            for (int rows = 0; rows < size; rows++)
            {
                for (int cols = 0; cols < size; cols++)
                {
                    Console.Write(matrix[rows, cols] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
