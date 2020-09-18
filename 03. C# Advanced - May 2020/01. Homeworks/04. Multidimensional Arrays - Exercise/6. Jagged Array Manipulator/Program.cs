using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] matrix = new double[n][];

            for (int rows = 0; rows < n; rows++)
            {
                matrix[rows] = Console.ReadLine()
                    .Split()
                    .Select(double.Parse)
                    .ToArray();
            }

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] /= 2;
                    }
                    for (int col = 0; col < matrix[row + 1].Length; col++)
                    {
                        matrix[row + 1][col] /= 2;
                    }
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] splitArgs = command.Split();

                if (command.Contains("Add"))
                {
                    int row = int.Parse(splitArgs[1]);
                    int col = int.Parse(splitArgs[2]);
                    int value = int.Parse(splitArgs[3]);

                    if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] += value;
                    }
                }
                if (command.Contains("Subtract"))
                {
                    int row = int.Parse(splitArgs[1]);
                    int col = int.Parse(splitArgs[2]);
                    int value = int.Parse(splitArgs[3]);

                    if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] -= value;
                    }
                }
            }

            foreach (double[] arr in matrix)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
