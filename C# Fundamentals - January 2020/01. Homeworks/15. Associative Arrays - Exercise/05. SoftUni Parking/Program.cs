using System;
using System.Collections.Generic;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> cars = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] action = Console.ReadLine().Split();

                if (action[0] == "register")
                {
                    string username = action[1];
                    string plateNum = action[2];

                    if (cars.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {plateNum}");
                    }
                    else
                    {
                        cars[username] = plateNum;
                        Console.WriteLine($"{username} registered {plateNum} successfully");
                    }
                }

                if (action[0] == "unregister")
                {
                    string username = action[1];

                    if (!cars.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }

                    else
                    {
                        cars.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
            }

            foreach (var user in cars)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
