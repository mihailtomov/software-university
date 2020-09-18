using System;

namespace _2._Enter_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    ReadNumber(start, end);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Number should be between {start} and {end}.");
                    i = -1;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Cannot enter a non-number text!");
                    i = -1;
                }
            }
        }

        static void ReadNumber(int start, int end)
        {
            try
            {
                int input = int.Parse(Console.ReadLine());

                if (input < start || input > end)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (FormatException)
            {
                throw;
            }
        }
    }
}
