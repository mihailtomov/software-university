using System;

namespace _2._Book_Worm
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialString = Console.ReadLine();
            int fieldSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[fieldSize, fieldSize];
            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < fieldSize; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();

                for (int col = 0; col < fieldSize; col++)
                {
                    matrix[row, col] = data[col];

                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                matrix[playerRow, playerCol] = '-';

                if (command == "up")
                {
                    if (playerRow - 1 >= 0)
                    {
                        playerRow--;

                        if (matrix[playerRow, playerCol] != '-')
                        {
                            initialString += matrix[playerRow, playerCol];
                            matrix[playerRow, playerCol] = 'P';
                        }
                    }
                    else
                    {
                        if (initialString.Length > 0)
                        {
                            initialString = initialString.Remove(initialString.Length - 1);
                            matrix[playerRow, playerCol] = 'P';
                        }
                    }
                }

                if (command == "down")
                {
                    if (playerRow + 1 < fieldSize)
                    {
                        playerRow++;

                        if (matrix[playerRow, playerCol] != '-')
                        {
                            initialString += matrix[playerRow, playerCol];
                            matrix[playerRow, playerCol] = 'P';
                        }
                    }
                    else
                    {
                        if (initialString.Length > 0)
                        {
                            initialString = initialString.Remove(initialString.Length - 1);
                            matrix[playerRow, playerCol] = 'P';
                        }
                    }
                }

                if (command == "left")
                {
                    if (playerCol - 1 >= 0)
                    {
                        playerCol--;

                        if (matrix[playerRow, playerCol] != '-')
                        {
                            initialString += matrix[playerRow, playerCol];
                            matrix[playerRow, playerCol] = 'P';
                        }
                    }
                    else
                    {
                        if (initialString.Length > 0)
                        {
                            initialString = initialString.Remove(initialString.Length - 1);
                            matrix[playerRow, playerCol] = 'P';
                        }
                    }
                }

                if (command == "right")
                {
                    if (playerCol + 1 < fieldSize)
                    {
                        playerCol++;

                        if (matrix[playerRow, playerCol] != '-')
                        {
                            initialString += matrix[playerRow, playerCol];
                            matrix[playerRow, playerCol] = 'P';
                        }
                    }
                    else
                    {
                        if (initialString.Length > 0)
                        {
                            initialString = initialString.Remove(initialString.Length - 1);
                            matrix[playerRow, playerCol] = 'P';
                        }
                    }
                }
            }

            Console.WriteLine(initialString);

            for (int row = 0; row < fieldSize; row++)
            {
                for (int col = 0; col < fieldSize; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }

                Console.WriteLine();
            }
        }
    }
}
