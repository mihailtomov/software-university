using System;

namespace SimpleOperationsAndCalculationsExcercises
{
    class Program
    {
        static void Main(string[] args)
        {
            // int -> integer numbers
            // double -> decimal numbers

            string name = "Ivan";
            string lastName = "Ivanov";
            int age = 22;

            //1:

            Console.WriteLine("I am " + name + " " + lastName + " age: " + age);

            //placeholders:

            Console.WriteLine("I am {0} {1} age: {2}", name, lastName, age);

            //interpolation:

            Console.WriteLine($"I am {name} {lastName} age: {age}");

            // Math

            double num = Math.Round(5.6);
            Console.WriteLine(num);

            // %

            Console.WriteLine(10 % 6);

            // CTRL + K + C / U - comment
            // CTRL + D - copy line
            // CTRL + L - delete line
            // CTRL + K + D - format code
            // how to create my own visual studio snippet -> google

            Console.WriteLine();

            Console.WriteLine(Math.Abs);

            int a = 5;
            int b = 2;
            double result = a / b;

            Camel case i Pascal case
        }
    }
}
