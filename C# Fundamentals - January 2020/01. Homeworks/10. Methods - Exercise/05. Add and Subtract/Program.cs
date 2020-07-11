using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        public static void Main(string[] args)
        {
            int firstInt = int.Parse(Console.ReadLine());
            int secondInt = int.Parse(Console.ReadLine());
            int thirdInt = int.Parse(Console.ReadLine());

            int result = Subtract(firstInt, secondInt, thirdInt);

            Console.WriteLine(result);
        }

        static int Sum(int firstInt, int secondInt)
        {
            int sum = firstInt + secondInt;
            return sum;
        }

        static int Subtract(int firstInt, int secondInt, int thirdInt)
        {
            int result = Sum(firstInt, secondInt) - thirdInt;
            return result;
        }
    }
}
