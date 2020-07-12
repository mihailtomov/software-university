using System;
using System.Linq;

namespace _03._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            string[] bombs = Console.ReadLine().Split();

            for (int i = 0; i < bombs.Length; i++)
            {
                string[] bombData = bombs[i]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);
                int bombRow = int.Parse(bombData[0]);
                int bombCol = int.Parse(bombData[1]);

                int bomb = matrix[bombRow, bombCol];

                if (bomb > 0)
                {
                    if (bombRow - 1 >= 0 && matrix[bombRow - 1, bombCol] > 0)
                    {
                        matrix[bombRow - 1, bombCol] -= bomb;
                    }
                    if (bombRow - 1 >= 0 && bombCol - 1 >= 0 && matrix[bombRow - 1, bombCol - 1] > 0)
                    {
                        matrix[bombRow - 1, bombCol - 1] -= bomb;
                    }
                    if (bombRow - 1 >= 0 && bombCol + 1 < size && matrix[bombRow - 1, bombCol + 1] > 0)
                    {
                        matrix[bombRow - 1, bombCol + 1] -= bomb;
                    }
                    if (bombCol - 1 >= 0 && matrix[bombRow, bombCol - 1] > 0)
                    {
                        matrix[bombRow, bombCol - 1] -= bomb;
                    }
                    if (bombCol + 1 < size && matrix[bombRow, bombCol + 1] > 0)
                    {
                        matrix[bombRow, bombCol + 1] -= bomb;
                    }
                    if (bombRow + 1 < size && matrix[bombRow + 1, bombCol] > 0)
                    {
                        matrix[bombRow + 1, bombCol] -= bomb;
                    }
                    if (bombRow + 1 < size && bombCol - 1 >= 0 && matrix[bombRow + 1, bombCol - 1] > 0)
                    {
                        matrix[bombRow + 1, bombCol - 1] -= bomb;
                    }
                    if (bombRow + 1 < size && bombCol + 1 < size && matrix[bombRow + 1, bombCol + 1] > 0)
                    {
                        matrix[bombRow + 1, bombCol + 1] -= bomb;
                    }

                    matrix[bombRow, bombCol] = 0;
                }
            }

            int aliveCells = 0;
            int sumOfCells = 0;

            foreach (var cell in matrix)
            {
                if (cell > 0)
                {
                    aliveCells++;
                    sumOfCells += cell;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumOfCells}");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
