using System;

namespace _02._Throne_Conquering
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int fieldSize = int.Parse(Console.ReadLine());

            char[][] matrix = new char[fieldSize][];
            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < fieldSize; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            bool throneReached = false;

            while (energy > 0 && throneReached == false)
            {
                string[] tokens = Console.ReadLine().Split();
                string direction = tokens[0];
                int enemyRow = int.Parse(tokens[1]);
                int enemyCol = int.Parse(tokens[2]);

                matrix[enemyRow][enemyCol] = 'S';
                matrix[playerRow][playerCol] = '-';

                if (direction == "up")
                {
                    if (playerRow - 1 >= 0)
                    {
                        playerRow--;
                        energy -= 1;

                        if (matrix[playerRow][playerCol] == 'S')
                        {
                            energy -= 2;

                            if (energy <= 0)
                            {
                                matrix[playerRow][playerCol] = 'X';
                                break;
                            }
                            else
                            {
                                matrix[playerRow][playerCol] = 'P';
                            }
                        }

                        if (matrix[playerRow][playerCol] == 'H')
                        {
                            matrix[playerRow][playerCol] = '-';
                            throneReached = true;
                            break;
                        }
                    }
                    else
                    {
                        energy -= 1;
                    }
                }

                if (direction == "down")
                {
                    if (playerRow + 1 < fieldSize)
                    {
                        playerRow++;
                        energy -= 1;

                        if (matrix[playerRow][playerCol] == 'S')
                        {
                            energy -= 2;

                            if (energy <= 0)
                            {
                                matrix[playerRow][playerCol] = 'X';
                                break;
                            }
                            else
                            {
                                matrix[playerRow][playerCol] = 'P';
                            }
                        }

                        if (matrix[playerRow][playerCol] == 'H')
                        {
                            matrix[playerRow][playerCol] = '-';
                            throneReached = true;
                            break;
                        }
                    }
                    else
                    {
                        energy -= 1;
                    }
                }

                if (direction == "left")
                {
                    if (playerCol - 1 >= 0)
                    {
                        playerCol--;
                        energy -= 1;

                        if (matrix[playerRow][playerCol] == 'S')
                        {
                            energy -= 2;

                            if (energy <= 0)
                            {
                                matrix[playerRow][playerCol] = 'X';
                                break;
                            }
                            else
                            {
                                matrix[playerRow][playerCol] = 'P';
                            }
                        }

                        if (matrix[playerRow][playerCol] == 'H')
                        {
                            matrix[playerRow][playerCol] = '-';
                            throneReached = true;
                            break;
                        }
                    }
                    else
                    {
                        energy -= 1;
                    }
                }

                if (direction == "right")
                {
                    if (playerCol + 1 < fieldSize)
                    {
                        playerCol++;
                        energy -= 1;

                        if (matrix[playerRow][playerCol] == 'S')
                        {
                            energy -= 2;

                            if (energy <= 0)
                            {
                                matrix[playerRow][playerCol] = 'X';
                                break;
                            }
                            else
                            {
                                matrix[playerRow][playerCol] = 'P';
                            }
                        }

                        if (matrix[playerRow][playerCol] == 'H')
                        {
                            matrix[playerRow][playerCol] = '-';
                            throneReached = true;
                            break;
                        }
                    }
                    else
                    {
                        energy -= 1;
                    }
                }

                if (energy <= 0)
                {
                    matrix[playerRow][playerCol] = 'X';
                    break;
                }
            }

            if (energy <= 0 && throneReached == false)
            {
                Console.WriteLine($"Paris died at {playerRow};{playerCol}.");
            }
            if (throneReached == true)
            {
                Console.WriteLine($"Paris has successfully sat on the throne! Energy left: {energy}");
            }

            for (int row = 0; row < fieldSize; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]}");
                }

                Console.WriteLine();
            }
        }
    }
}
