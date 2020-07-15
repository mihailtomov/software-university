using System;

namespace _02._Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];

            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < matrixSize; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = data[col];

                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            bool hasWon = false;

            for (int i = 0; i < commandsCount; i++)
            {
                if (matrix[playerRow, playerCol] == 'F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    hasWon = true;
                    break;
                }

                string command = Console.ReadLine();

                matrix[playerRow, playerCol] = '-';

                if (command == "up")
                {
                    playerRow--;

                    if (playerRow == -1)
                    {
                        playerRow = matrixSize - 1;
                    }

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerRow--;

                        if (playerRow == -1)
                        {
                            playerRow = matrixSize - 1;
                        }
                    }

                    if (matrix[playerRow, playerCol] == 'T')
                    {
                        playerRow++;
                    }

                    if (matrix[playerRow, playerCol] != 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                    }
                 }

                if (command == "down")
                {
                    playerRow++;

                    if (playerRow == matrixSize)
                    {
                        playerRow = 0;
                    }

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerRow++;

                        if (playerRow == matrixSize)
                        {
                            playerRow = 0;
                        }
                    }

                    if (matrix[playerRow, playerCol] == 'T')
                    {
                        playerRow--;
                    }

                    if (matrix[playerRow, playerCol] != 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                    }
                }

                if (command == "left")
                {
                    playerCol--;

                    if (playerCol == -1)
                    {
                        playerCol = matrixSize - 1;
                    }

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerCol--;

                        if (playerCol == -1)
                        {
                            playerCol = matrixSize - 1;
                        }
                    }

                    if (matrix[playerRow, playerCol] == 'T')
                    {
                        playerCol++;
                    }

                    if (matrix[playerRow, playerCol] != 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                    }
                }

                if (command == "right")
                {
                    playerCol++;

                    if (playerCol == matrixSize)
                    {
                        playerCol = 0;
                    }

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerCol++;

                        if (playerCol == matrixSize)
                        {
                            playerCol = 0;
                        }
                    }

                    if (matrix[playerRow, playerCol] == 'T')
                    {
                        playerCol--;
                    }

                    if (matrix[playerRow, playerCol] != 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                    }
                }

                if (matrix[playerRow, playerCol] == 'F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    hasWon = true;
                    break;
                }
            }

            if (hasWon == true)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }

                Console.WriteLine();
            }
        }
    }
}
