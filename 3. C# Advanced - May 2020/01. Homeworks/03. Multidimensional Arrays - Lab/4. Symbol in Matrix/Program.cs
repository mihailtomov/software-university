using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                char[] chars = Console.ReadLine().ToCharArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = chars[cols];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            int row = -1;
            int col = -1;
            bool isFound = false;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    char currCh = matrix[rows, cols];

                    if (currCh == symbol)
                    {
                        row = rows;
                        col = cols;
                        isFound = true;
                        break;
                    }
                }

                if (isFound == true)
                {
                    break;
                }
            }

            if (isFound == true)
            {
                Console.WriteLine($"({row}, {col})");
            }
            else
            {
                Console.WriteLine($"{symbol} does not occur in the matrix ");
            }
        }
    }
}
