using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] square = new int[size, size];
            int sumOfPrimaryDiagonal = 0;

            for (int rows = 0; rows < square.GetLength(0); rows++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int cols = 0; cols < square.GetLength(1); cols++)
                {
                    square[rows, cols] = nums[cols];

                    if (rows == cols)
                    {
                        sumOfPrimaryDiagonal += square[rows, cols];
                    }
                }
            }

            Console.WriteLine(sumOfPrimaryDiagonal);
        }
    }
}
