using System;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lairSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char[lairSize[0], lairSize[1]];
            int playerRow = 0;
            int playerCol = 0;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                string input = Console.ReadLine();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = input[cols];
                    char currCh = matrix[rows, cols];

                    if (currCh == 'P')
                    {
                        playerRow = rows;
                        playerCol = cols;
                    }
                }
            }

            string directions = Console.ReadLine();
            int row = playerRow;
            int col = playerCol;
            bool isDead = false;
            bool hasWon = false;

            for (int i = 0; i < directions.Length; i++)
            {
                char currDirection = directions[i];

                if (currDirection == 'L')
                {
                    if (col - 1 >= 0)
                    {
                        char player = matrix[row, col];
                        matrix[row, col] = '.';
                        col = col - 1;
                        
                        if (matrix[row, col] == 'B')
                        {
                            isDead = true;
                        }
                        else
                        {
                            matrix[row, col] = player;
                        }
                    }
                    else
                    {
                        hasWon = true;
                        matrix[row, col] = '.';
                    }
                }
                if (currDirection == 'R')
                {
                    if (col + 1 < matrix.GetLength(1))
                    {
                        char player = matrix[row, col];
                        matrix[row, col] = '.';
                        col = col + 1;

                        if (matrix[row, col] == 'B')
                        {
                            isDead = true;
                        }
                        else
                        {
                            matrix[row, col] = player;
                        }
                    }
                    else
                    {
                        hasWon = true;
                        matrix[row, col] = '.';
                    }
                }
                if (currDirection == 'U')
                {
                    if (row - 1 >= 0)
                    {
                        char player = matrix[row, col];
                        matrix[row, col] = '.';
                        row = row - 1;

                        if (matrix[row, col] == 'B')
                        {
                            isDead = true;
                        }
                        else
                        {
                            matrix[row, col] = player;
                        }
                    }
                    else
                    {
                        hasWon = true;
                        matrix[row, col] = '.';
                    }
                }
                if (currDirection == 'D')
                {
                    if (row + 1 < matrix.GetLength(0))
                    {
                        char player = matrix[row, col];
                        matrix[row, col] = '.';
                        row = row + 1;

                        if (matrix[row, col] == 'B')
                        {
                            isDead = true;
                        }
                        else
                        {
                            matrix[row, col] = player;
                        }
                    }
                    else
                    {
                        hasWon = true;
                        matrix[row, col] = '.';
                    }
                }

                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    for (int cols = 0; cols < matrix.GetLength(1); cols++)
                    {
                        char currCh = matrix[rows, cols];

                        if (currCh == 'B')
                        {
                            if (cols - 1 >= 0)
                            {
                                if (matrix[rows, cols - 1] == '.')
                                {
                                    matrix[rows, cols - 1] = 'T';
                                }
                                else if (matrix[rows, cols - 1] == 'P')
                                {
                                    isDead = true;
                                    matrix[rows, cols - 1] = 'T';
                                }
                            }
                            if (cols + 1 < matrix.GetLength(1))
                            {
                                if (matrix[rows, cols + 1] == '.')
                                {
                                    matrix[rows, cols + 1] = 'T';
                                }
                                else if (matrix[rows, cols + 1] == 'P')
                                {
                                    isDead = true;
                                    matrix[rows, cols + 1] = 'T';
                                }
                            }
                            if (rows - 1 >= 0)
                            {
                                if (matrix[rows - 1, cols] == '.')
                                {
                                    matrix[rows - 1, cols] = 'T';
                                }
                                else if (matrix[rows - 1, cols] == 'P')
                                {
                                    isDead = true;
                                    matrix[rows - 1, cols] = 'T';
                                }
                            }
                            if (rows + 1 < matrix.GetLength(0))
                            {
                                if (matrix[rows + 1, cols] == '.')
                                {
                                    matrix[rows + 1, cols] = 'T';
                                }
                                else if (matrix[rows + 1, cols] == 'P')
                                {
                                    isDead = true;
                                    matrix[rows + 1, cols] = 'T';
                                }
                            }
                        }
                    }
                }

                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    for (int cols = 0; cols < matrix.GetLength(1); cols++)
                    {
                        if (matrix[rows, cols] == 'T')
                        {
                            matrix[rows, cols] = 'B';
                        }
                    }
                }

                if (isDead == true || hasWon == true)
                {
                    break;
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

            if (isDead == true)
            {
                Console.WriteLine($"dead: {row} {col}");
            }
            if (hasWon == true)
            {
                Console.WriteLine($"won: {row} {col}");
            }
        }
    }
}
