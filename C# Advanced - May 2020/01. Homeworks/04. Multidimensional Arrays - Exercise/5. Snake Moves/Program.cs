using System;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char[size[0], size[1]];
            string initialSnake = Console.ReadLine();
            string snake = initialSnake;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                if (rows % 2 == 0)
                {
                    for (int cols = 0; cols < matrix.GetLength(1); cols++)
                    {
                        matrix[rows, cols] = snake[0];
                        snake = snake.Remove(0, 1);

                        if (snake.Length == 0)
                        {
                            snake = initialSnake;
                        }
                    }
                }
                else
                {
                    for (int cols = matrix.GetLength(1) - 1; cols >= 0; cols--)
                    {
                        matrix[rows, cols] = snake[0];
                        snake = snake.Remove(0, 1);

                        if (snake.Length == 0)
                        {
                            snake = initialSnake;
                        }
                    }
                }
            }

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write(matrix[rows, cols]);
                }
                Console.WriteLine();
            }
        }
    }
}
