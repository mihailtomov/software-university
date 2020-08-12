using System;

namespace _6._Valid_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Person pesho = new Person("Pesho", "Peshev", 24);

            try
            {
                Person noName = new Person(string.Empty, "Goshev", 31);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Exception thrown: {e.Message}");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Exception thrown: {e.Message}");
            }

            try
            {
                Person noLastName = new Person("Ivan", null, 63);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Exception thrown: {e.Message}");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Exception thrown: {e.Message}");
            }

            try
            {
                Person negativeAge = new Person("Stoyan", "Kolev", -1);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Exception thrown: {e.Message}");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Exception thrown: {e.Message}");
            }

            try
            {
                Person tooOldForThisProgram = new Person("Iskren", "Ivanov", 121);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Exception thrown: {e.Message}");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Exception thrown: {e.Message}");
            }
        }
    }
}
