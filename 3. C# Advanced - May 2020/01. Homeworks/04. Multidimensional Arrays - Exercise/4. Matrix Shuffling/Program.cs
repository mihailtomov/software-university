using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = new string[sizes[0], sizes[1]];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                string[] data = Console.ReadLine().Split();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = data[cols];
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] splitArgs = command.Split();

                if (command.Contains("swap") && splitArgs.Length == 5)
                {
                    int row1 = int.Parse(splitArgs[1]);
                    int col1 = int.Parse(splitArgs[2]);
                    int row2 = int.Parse(splitArgs[3]);
                    int col2 = int.Parse(splitArgs[4]);

                    if ((row1 >= 0 && row1 < matrix.GetLength(0)) && (col1 >= 0 && col1 < matrix.GetLength(1)) 
                     && (row2 >= 0 && row2 < matrix.GetLength(0)) && (col2 >= 0 && col2 < matrix.GetLength(1)))
                    {
                        string temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;

                        for (int rows = 0; rows < matrix.GetLength(0); rows++)
                        {
                            for (int cols = 0; cols < matrix.GetLength(1); cols++)
                            {
                                Console.Write($"{matrix[rows, cols]} ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    } 
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
