using System;

namespace _1._Square_Root
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 0)
                {
                    Console.WriteLine("Invalid number");
                }
                else
                {
                    Console.WriteLine(Math.Sqrt(number));
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
