using System;
using System.Linq;

namespace _2._Present_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int presentsCount = int.Parse(Console.ReadLine());
            int neighbourhoodSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[neighbourhoodSize, neighbourhoodSize];
            int santaRow = -1;
            int santaCol = -1;
            int totalNiceKids = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] data = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];

                    if (matrix[row, col] == 'S')
                    {
                        santaRow = row;
                        santaCol = col;
                    }
                    if (matrix[row, col] == 'V')
                    {
                        totalNiceKids++;
                    }
                }
            }

            int giftedPresents = 0;

            string command;

            while ((command = Console.ReadLine()) != "Christmas morning")
            {
                matrix[santaRow, santaCol] = '-';

                switch (command)
                {
                    case "up":
                        santaRow--;
                        break;
                    case "down":
                        santaRow++;
                        break;
                    case "left":
                        santaCol--;
                        break;
                    case "right":
                        santaCol++;
                        break;
                }

                if (matrix[santaRow, santaCol] == 'V')
                {
                    giftedPresents++;
                    presentsCount--;
                    matrix[santaRow, santaCol] = 'S';
                }
                if (matrix[santaRow, santaCol] == 'C')
                {
                    matrix[santaRow, santaCol] = 'S';

                    if (matrix[santaRow - 1, santaCol] == 'V')
                    {
                        giftedPresents++;
                        presentsCount--;
                        matrix[santaRow - 1, santaCol] = '-';
                    }
                    else if (matrix[santaRow - 1, santaCol] == 'X')
                    {
                        matrix[santaRow - 1, santaCol] = '-';
                        presentsCount--;
                    }

                    if (matrix[santaRow + 1, santaCol] == 'V')
                    {
                        giftedPresents++;
                        presentsCount--;
                        matrix[santaRow + 1, santaCol] = '-';
                    }
                    else if (matrix[santaRow + 1, santaCol] == 'X')
                    {
                        matrix[santaRow + 1, santaCol] = '-';
                        presentsCount--;
                    }

                    if (matrix[santaRow, santaCol - 1] == 'V')
                    {
                        giftedPresents++;
                        presentsCount--;
                        matrix[santaRow, santaCol - 1] = '-';
                    }
                    else if (matrix[santaRow, santaCol - 1] == 'X')
                    {
                        matrix[santaRow, santaCol - 1] = '-';
                        presentsCount--;
                    }

                    if (matrix[santaRow, santaCol + 1] == 'V')
                    {
                        giftedPresents++;
                        presentsCount--;
                        matrix[santaRow, santaCol + 1] = '-';
                    }
                    else if (matrix[santaRow, santaCol + 1] == 'X')
                    {
                        matrix[santaRow, santaCol + 1] = '-';
                        presentsCount--;
                    }
                }

                if (presentsCount == 0)
                {
                    break;
                }
            }

            if (presentsCount == 0)
            {
                Console.WriteLine("Santa ran out of presents!");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }

            if (giftedPresents == totalNiceKids)
            {
                Console.WriteLine($"Good job, Santa! {totalNiceKids} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {totalNiceKids - giftedPresents} nice kid/s.");
            }
        }
    }
}
