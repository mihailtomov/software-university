using System;

namespace VariableExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            //string result = firstName + " " + lastName + " @ " + age + " years old!";

            string result = $"{firstName} {lastName} @ {age} years old!";

            //Console.WriteLine("{0} {1} @ {2} years old!", firstName , lastName, age);
            Console.WriteLine(result);
               
        }
    }
}