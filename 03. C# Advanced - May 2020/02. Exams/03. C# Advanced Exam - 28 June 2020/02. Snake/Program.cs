using System;

namespace _02._Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int snakeRow = -1;
            int snakeCol = -1;

            int burrow1Row = -1;
            int burrow1Col = -1;
            int burrow2Row = -1;
            int burrow2Col = -1;

            int counter = 1;

            for (int row = 0; row < size; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = data[col];

                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }

                    if (matrix[row, col] == 'B')
                    {
                        if (counter == 1)
                        {
                            burrow1Row = row;
                            burrow1Col = col;
                            counter++;
                        }
                        else
                        {
                            burrow2Row = row;
                            burrow2Col = col;
                        }
                    }
                }
            }

            int foodQuantity = 0;
            bool isOutside = false;

            while (foodQuantity < 10 && isOutside == false)
            {
                string command = Console.ReadLine();

                matrix[snakeRow, snakeCol] = '.';

                if (command == "up")
                {
                    if (snakeRow - 1 >= 0)
                    {
                        snakeRow--;

                        if (matrix[snakeRow, snakeCol] == '*')
                        {
                            matrix[snakeRow, snakeCol] = 'S';
                            foodQuantity += 1;
                        }
                        if ((snakeRow == burrow1Row && snakeCol == burrow1Col) || (snakeRow == burrow2Row && snakeCol == burrow2Col))
                        {
                            if (snakeRow == burrow1Row && snakeCol == burrow1Col)
                            {
                                snakeRow = burrow2Row;
                                snakeCol = burrow2Col;

                                matrix[burrow1Row, burrow1Col] = '.';
                                matrix[burrow2Row, burrow2Col] = '.';
                            }
                            else
                            {
                                snakeRow = burrow1Row;
                                snakeCol = burrow1Col;

                                matrix[burrow1Row, burrow1Col] = '.';
                                matrix[burrow2Row, burrow2Col] = '.';
                            }
                        }
                    }
                    else
                    {
                        isOutside = true;
                        break;
                    }
                }

                if (command == "down")
                {
                    if (snakeRow + 1 < size)
                    {
                        snakeRow++;

                        if (matrix[snakeRow, snakeCol] == '*')
                        {
                            matrix[snakeRow, snakeCol] = 'S';
                            foodQuantity += 1;
                        }
                        if ((snakeRow == burrow1Row && snakeCol == burrow1Col) || (snakeRow == burrow2Row && snakeCol == burrow2Col))
                        {
                            if (snakeRow == burrow1Row && snakeCol == burrow1Col)
                            {
                                snakeRow = burrow2Row;
                                snakeCol = burrow2Col;

                                matrix[burrow1Row, burrow1Col] = '.';
                                matrix[burrow2Row, burrow2Col] = '.';
                            }
                            else
                            {
                                snakeRow = burrow1Row;
                                snakeCol = burrow1Col;

                                matrix[burrow1Row, burrow1Col] = '.';
                                matrix[burrow2Row, burrow2Col] = '.';
                            }
                        }
                    }
                    else
                    {
                        isOutside = true;
                        break;
                    }
                }

                if (command == "left")
                {
                    if (snakeCol - 1 >= 0)
                    {
                        snakeCol--;

                        if (matrix[snakeRow, snakeCol] == '*')
                        {
                            matrix[snakeRow, snakeCol] = 'S';
                            foodQuantity += 1;
                        }
                        if ((snakeRow == burrow1Row && snakeCol == burrow1Col) || (snakeRow == burrow2Row && snakeCol == burrow2Col))
                        {
                            if (snakeRow == burrow1Row && snakeCol == burrow1Col)
                            {
                                snakeRow = burrow2Row;
                                snakeCol = burrow2Col;

                                matrix[burrow1Row, burrow1Col] = '.';
                                matrix[burrow2Row, burrow2Col] = '.';
                            }
                            else
                            {
                                snakeRow = burrow1Row;
                                snakeCol = burrow1Col;

                                matrix[burrow1Row, burrow1Col] = '.';
                                matrix[burrow2Row, burrow2Col] = '.';
                            }
                        }
                    }
                    else
                    {
                        isOutside = true;
                        break;
                    }
                }

                if (command == "right")
                {
                    if (snakeCol + 1 < size)
                    {
                        snakeCol++;

                        if (matrix[snakeRow, snakeCol] == '*')
                        {
                            matrix[snakeRow, snakeCol] = 'S';
                            foodQuantity += 1;
                        }
                        if ((snakeRow == burrow1Row && snakeCol == burrow1Col) || (snakeRow == burrow2Row && snakeCol == burrow2Col))
                        {
                            if (snakeRow == burrow1Row && snakeCol == burrow1Col)
                            {
                                snakeRow = burrow2Row;
                                snakeCol = burrow2Col;

                                matrix[burrow1Row, burrow1Col] = '.';
                                matrix[burrow2Row, burrow2Col] = '.';
                            }
                            else
                            {
                                snakeRow = burrow1Row;
                                snakeCol = burrow1Col;

                                matrix[burrow1Row, burrow1Col] = '.';
                                matrix[burrow2Row, burrow2Col] = '.';
                            }
                        }
                    }
                    else
                    {
                        isOutside = true;
                        break;
                    }
                }
            }

            if (isOutside == true)
            {
                Console.WriteLine("Game over!");
            }
            if (foodQuantity >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodQuantity}");

            for (int row = 0; row < size; row++)
            {  
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }

                Console.WriteLine();
            }
        }
    }
}
