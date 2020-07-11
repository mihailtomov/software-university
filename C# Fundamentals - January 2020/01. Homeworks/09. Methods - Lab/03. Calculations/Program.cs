using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            switch (operation)
            {
                case "add":
                    PrintAddNumbers(firstNum, secondNum);
                    break;
                case "multiply":
                    PrintMultiplyNumbers(firstNum, secondNum);
                    break;
                case "subtract":
                    PrintSubtractNumbers(firstNum, secondNum);
                    break;
                case "divide":
                    PrintDivideNumbers(firstNum, secondNum);
                    break;
            }
        }

        static void PrintAddNumbers(int num1, int num2)
        {
            Console.WriteLine(num1 + num2);
        }

        static void PrintMultiplyNumbers(int num1, int num2)
        {
            Console.WriteLine(num1 * num2);
        }

        static void PrintSubtractNumbers(int num1, int num2)
        {
            Console.WriteLine(num1 - num2);
        }

        static void PrintDivideNumbers(int num1, int num2)
        {
            Console.WriteLine(num1 / num2);
        }
    }
}
