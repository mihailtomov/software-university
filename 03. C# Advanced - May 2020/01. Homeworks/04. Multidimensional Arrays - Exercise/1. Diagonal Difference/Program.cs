using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = nums[cols];
                }
            }

            int primarySum = 0;
            int secondarySum = 0;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (rows == cols)
                    {
                        primarySum += matrix[rows, cols];
                    }
                    if (cols == matrix.GetLength(1) - 1 - rows)
                    {
                        secondarySum += matrix[rows, cols];
                    }
                }
            }

            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }
    }
}
