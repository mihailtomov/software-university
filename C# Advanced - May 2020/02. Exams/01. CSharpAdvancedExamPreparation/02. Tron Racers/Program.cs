using System;

namespace _02._Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int p1Row = -1;
            int p1Col = -1;
            int p2Row = -1;
            int p2Col = -1;

            for (int row = 0; row < size; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = data[col];

                    if (matrix[row, col] == 'f')
                    {
                        p1Row = row;
                        p1Col = col;
                    }
                    if (matrix[row, col] == 's')
                    {
                        p2Row = row;
                        p2Col = col;
                    }
                }
            }

            bool p1IsDead = false;
            bool p2IsDead = false;

            while (p1IsDead == false && p2IsDead == false)
            {
                string[] commands = Console.ReadLine().Split();
                string p1Command = commands[0];
                string p2Command = commands[1];

                if (p1Command == "up")
                {
                    if (p1Row - 1 >= 0)
                    {
                        p1Row--;

                        if (matrix[p1Row, p1Col] != 's')
                        {
                            matrix[p1Row, p1Col] = 'f';
                        }
                        else
                        {
                            matrix[p1Row, p1Col] = 'x';
                            p1IsDead = true;
                            break;
                        }
                    }
                    else
                    {
                        p1Row = size - 1;

                        if (matrix[p1Row, p1Col] != 's')
                        {
                            matrix[p1Row, p1Col] = 'f';
                        }
                        else
                        {
                            matrix[p1Row, p1Col] = 'x';
                            p1IsDead = true;
                            break;
                        }
                    }
                }

                if (p1Command == "down")
                {
                    if (p1Row + 1 < size)
                    {
                        p1Row++;

                        if (matrix[p1Row, p1Col] != 's')
                        {
                            matrix[p1Row, p1Col] = 'f';
                        }
                        else
                        {
                            matrix[p1Row, p1Col] = 'x';
                            p1IsDead = true;
                            break;
                        }
                    }
                    else
                    {
                        p1Row = 0;

                        if (matrix[p1Row, p1Col] != 's')
                        {
                            matrix[p1Row, p1Col] = 'f';
                        }
                        else
                        {
                            matrix[p1Row, p1Col] = 'x';
                            p1IsDead = true;
                            break;
                        }
                    }
                }

                if (p1Command == "left")
                {
                    if (p1Col - 1 >= 0)
                    {
                        p1Col--;

                        if (matrix[p1Row, p1Col] != 's')
                        {
                            matrix[p1Row, p1Col] = 'f';
                        }
                        else
                        {
                            matrix[p1Row, p1Col] = 'x';
                            p1IsDead = true;
                            break;
                        }
                    }
                    else
                    {
                        p1Col = size - 1;

                        if (matrix[p1Row, p1Col] != 's')
                        {
                            matrix[p1Row, p1Col] = 'f';
                        }
                        else
                        {
                            matrix[p1Row, p1Col] = 'x';
                            p1IsDead = true;
                            break;
                        }
                    }
                }

                if (p1Command == "right")
                {
                    if (p1Col + 1 < size)
                    {
                        p1Col++;

                        if (matrix[p1Row, p1Col] != 's')
                        {
                            matrix[p1Row, p1Col] = 'f';
                        }
                        else
                        {
                            matrix[p1Row, p1Col] = 'x';
                            p1IsDead = true;
                            break;
                        }
                    }
                    else
                    {
                        p1Col = 0;

                        if (matrix[p1Row, p1Col] != 's')
                        {
                            matrix[p1Row, p1Col] = 'f';
                        }
                        else
                        {
                            matrix[p1Row, p1Col] = 'x';
                            p1IsDead = true;
                            break;
                        }
                    }
                }

                if (p2Command == "up")
                {
                    if (p2Row - 1 >= 0)
                    {
                        p2Row--;

                        if (matrix[p2Row, p2Col] != 'f')
                        {
                            matrix[p2Row, p2Col] = 's';
                        }
                        else
                        {
                            matrix[p2Row, p2Col] = 'x';
                            p2IsDead = true;
                            break;
                        }
                    }
                    else
                    {
                        p2Row = size - 1;

                        if (matrix[p2Row, p2Col] != 'f')
                        {
                            matrix[p2Row, p2Col] = 's';
                        }
                        else
                        {
                            matrix[p2Row, p2Col] = 'x';
                            p2IsDead = true;
                            break;
                        }
                    }
                }

                if (p2Command == "down")
                {
                    if (p2Row + 1 < size)
                    {
                        p2Row++;

                        if (matrix[p2Row, p2Col] != 'f')
                        {
                            matrix[p2Row, p2Col] = 's';
                        }
                        else
                        {
                            matrix[p2Row, p2Col] = 'x';
                            p2IsDead = true;
                            break;
                        }
                    }
                    else
                    {
                        p2Row = 0;

                        if (matrix[p2Row, p2Col] != 'f')
                        {
                            matrix[p2Row, p2Col] = 's';
                        }
                        else
                        {
                            matrix[p2Row, p2Col] = 'x';
                            p2IsDead = true;
                            break;
                        }
                    }
                }

                if (p2Command == "left")
                {
                    if (p2Col - 1 >= 0)
                    {
                        p2Col--;

                        if (matrix[p2Row, p2Col] != 'f')
                        {
                            matrix[p2Row, p2Col] = 's';
                        }
                        else
                        {
                            matrix[p2Row, p2Col] = 'x';
                            p2IsDead = true;
                            break;
                        }
                    }
                    else
                    {
                        p2Col = size - 1;

                        if (matrix[p2Row, p2Col] != 'f')
                        {
                            matrix[p2Row, p2Col] = 's';
                        }
                        else
                        {
                            matrix[p2Row, p2Col] = 'x';
                            p2IsDead = true;
                            break;
                        }
                    }
                }

                if (p2Command == "right")
                {
                    if (p2Col + 1 < size)
                    {
                        p2Col++;

                        if (matrix[p2Row, p2Col] != 'f')
                        {
                            matrix[p2Row, p2Col] = 's';
                        }
                        else
                        {
                            matrix[p2Row, p2Col] = 'x';
                            p2IsDead = true;
                            break;
                        }
                    }
                    else
                    {
                        p2Col = 0;

                        if (matrix[p2Row, p2Col] != 'f')
                        {
                            matrix[p2Row, p2Col] = 's';
                        }
                        else
                        {
                            matrix[p2Row, p2Col] = 'x';
                            p2IsDead = true;
                            break;
                        }
                    }
                }
            }

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
