using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = nums[cols];
                }
            }

            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                int colSum = 0;

                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    colSum += matrix[rows, cols];
                }

                Console.WriteLine(colSum);
            }
        }
    }
}
