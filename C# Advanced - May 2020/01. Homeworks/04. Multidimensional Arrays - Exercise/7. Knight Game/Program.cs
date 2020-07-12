using System;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                string data = Console.ReadLine();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = data[cols];
                }
            }

            int knightsToBeRemoved = 0;

            while (true)
            {
                int maxHitsCount = 0;
                int maxRow = 0;
                int maxCol = 0;

                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    for (int cols = 0; cols < matrix.GetLength(1); cols++)
                    {
                        int currHitsCount = 0;

                        if (matrix[rows, cols] == 'K')
                        {
                            if (rows - 2 >= 0)
                            {
                                if (cols - 1 >= 0)
                                {
                                    if (matrix[rows - 2, cols - 1] == 'K')
                                    {
                                        currHitsCount++;
                                    }
                                }
                                if (cols + 1 < matrix.GetLength(1))
                                {
                                    if (matrix[rows - 2, cols + 1] == 'K')
                                    {
                                        currHitsCount++;
                                    }
                                }                              
                            }
                            if (rows - 1 >= 0)
                            {
                                if (cols - 2 >= 0)
                                {
                                    if (matrix[rows - 1, cols - 2] == 'K')
                                    {
                                        currHitsCount++;
                                    }
                                }
                                if (cols + 2 < matrix.GetLength(1))
                                {
                                    if (matrix[rows - 1, cols + 2] == 'K')
                                    {
                                        currHitsCount++;
                                    }
                                }
                            }
                            if (rows + 2 < matrix.GetLength(0))
                            {
                                if (cols - 1 >= 0)
                                {
                                    if (matrix[rows + 2, cols - 1] == 'K')
                                    {
                                        currHitsCount++;
                                    }
                                }
                                if (cols + 1 < matrix.GetLength(1))
                                {
                                    if (matrix[rows + 2, cols + 1] == 'K')
                                    {
                                        currHitsCount++;
                                    }
                                }                              
                            }
                            if (rows + 1 < matrix.GetLength(0))
                            {
                                if (cols - 2 >= 0)
                                {
                                    if (matrix[rows + 1, cols - 2] == 'K')
                                    {
                                        currHitsCount++;
                                    }
                                }
                                if (cols + 2 < matrix.GetLength(1))
                                {
                                    if (matrix[rows + 1, cols + 2] == 'K')
                                    {
                                        currHitsCount++;
                                    }
                                }
                            }
                        }

                        if (currHitsCount > maxHitsCount)
                        {
                            maxHitsCount = currHitsCount;
                            maxRow = rows;
                            maxCol = cols;
                        }
                    }
                }

                if (maxHitsCount > 0)
                {
                    knightsToBeRemoved++;
                    matrix[maxRow, maxCol] = '0';
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(knightsToBeRemoved);
        }
    }
}
