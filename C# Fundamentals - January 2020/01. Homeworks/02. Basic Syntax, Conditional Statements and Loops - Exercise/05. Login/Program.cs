using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string reversed = "";
            int counter = 1;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                reversed += username[i];
            }

            string password = Console.ReadLine();

            while (password != reversed)
            {
                if (counter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }

                Console.WriteLine("Incorrect password. Try again.");
                counter++;
                password = Console.ReadLine();
            }

            if (password == reversed)
            {
                Console.WriteLine($"User {username} logged in.");
            }
            
        }
    }
}
