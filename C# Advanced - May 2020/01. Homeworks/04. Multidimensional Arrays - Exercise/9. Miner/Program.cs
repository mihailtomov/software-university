using System;

namespace _9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split();
            char[,] matrix = new char[fieldSize, fieldSize];

            int totalCoalCount = 0;
            int startRow = 0;
            int startCol = 0;

            for (int rows = 0; rows < fieldSize; rows++)
            {
                string[] data = Console.ReadLine().Split();

                for (int cols = 0; cols < fieldSize; cols++)
                {
                    matrix[rows, cols] = char.Parse(data[cols]);
                    char currCh = matrix[rows, cols];

                    if (currCh == 's')
                    {
                        startRow = rows;
                        startCol = cols;
                    }
                    if (currCh == 'c')
                    {
                        totalCoalCount++;
                    }
                }
            }

            int collectedCoalCount = 0;
            int rowIndex = startRow;
            int colIndex = startCol;

            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i];

                if (command == "left" && colIndex - 1 >= 0)
                {
                    colIndex = colIndex - 1;

                    if (matrix[rowIndex, colIndex] == 'c')
                    {
                        collectedCoalCount++;
                        matrix[rowIndex, colIndex] = '*';

                        if (collectedCoalCount == totalCoalCount)
                        {
                            Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                            return;
                        }
                    }
                    if (matrix[rowIndex, colIndex] == 'e')
                    {
                        Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                        return;
                    }
                }
                if (command == "right" && colIndex + 1 < fieldSize)
                {
                    colIndex = colIndex + 1;

                    if (matrix[rowIndex, colIndex] == 'c')
                    {
                        collectedCoalCount++;
                        matrix[rowIndex, colIndex] = '*';

                        if (collectedCoalCount == totalCoalCount)
                        {
                            Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                            return;
                        }
                    }
                    if (matrix[rowIndex, colIndex] == 'e')
                    {
                        Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                        return;
                    }
                }
                if (command == "up" && rowIndex - 1 >= 0)
                {
                    rowIndex = rowIndex - 1;

                    if (matrix[rowIndex, colIndex] == 'c')
                    {
                        collectedCoalCount++;
                        matrix[rowIndex, colIndex] = '*';

                        if (collectedCoalCount == totalCoalCount)
                        {
                            Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                            return;
                        }
                    }
                    if (matrix[rowIndex, colIndex] == 'e')
                    {
                        Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                        return;
                    }
                }
                if (command == "down" && rowIndex + 1 < fieldSize)
                {
                    rowIndex = rowIndex + 1;

                    if (matrix[rowIndex, colIndex] == 'c')
                    {
                        collectedCoalCount++;
                        matrix[rowIndex, colIndex] = '*';

                        if (collectedCoalCount == totalCoalCount)
                        {
                            Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                            return;
                        }
                    }
                    if (matrix[rowIndex, colIndex] == 'e')
                    {
                        Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{totalCoalCount - collectedCoalCount} coals left. ({rowIndex}, {colIndex})");
        }     
    }
}
