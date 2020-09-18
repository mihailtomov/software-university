using System;

namespace _03._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());

            string gameName = Console.ReadLine();
            double totalSpent = 0;

            while (gameName != "Game Time")
            {
                if (gameName == "OutFall 4" && currentBalance >= 39.99)
                {
                    currentBalance -= 39.99;
                    totalSpent += 39.99;
                    Console.WriteLine($"Bought {gameName}");
                }

                else if (gameName == "OutFall 4" && currentBalance < 39.99)
                {
                    currentBalance += 0;
                    totalSpent += 0;
                    Console.WriteLine("Too Expensive");
                }

                if (gameName == "CS: OG" && currentBalance >= 15.99)
                {
                    currentBalance -= 15.99;
                    totalSpent += 15.99;
                    Console.WriteLine($"Bought {gameName}");
                }

                else if (gameName == "CS: OG" && currentBalance < 39.99)
                {
                    currentBalance += 0;
                    totalSpent += 0;
                    Console.WriteLine("Too Expensive");
                }

                if (gameName == "Zplinter Zell" && currentBalance >= 19.99)
                {
                    currentBalance -= 19.99;
                    totalSpent += 19.99;
                    Console.WriteLine($"Bought {gameName}");
                }

                else if (gameName == "Zplinter Zell" && currentBalance < 39.99)
                {
                    currentBalance += 0;
                    totalSpent += 0;
                    Console.WriteLine("Too Expensive");
                }

                if (gameName == "Honored 2" && currentBalance >= 59.99)
                {
                    currentBalance -= 59.99;
                    totalSpent += 59.99;
                    Console.WriteLine($"Bought {gameName}");
                }

                else if (gameName == "Honored 2" && currentBalance < 39.99)
                {
                    currentBalance += 0;
                    totalSpent += 0;
                    Console.WriteLine("Too Expensive");
                }

                if (gameName == "RoverWatch" && currentBalance >= 29.99)
                {
                    currentBalance -= 29.99;
                    totalSpent += 29.99;
                    Console.WriteLine($"Bought {gameName}");
                }

                else if (gameName == "RoverWatch" && currentBalance < 39.99)
                {
                    currentBalance += 0;
                    totalSpent += 0;
                    Console.WriteLine("Too Expensive");
                }

                if (gameName == "RoverWatch Origins Edition" && currentBalance >= 39.99)
                {
                    currentBalance -= 39.99;
                    totalSpent += 39.99;
                    Console.WriteLine($"Bought {gameName}");
                }

                else if (gameName == "RoverWatch Origins Edition" && currentBalance < 39.99)
                {
                    currentBalance += 0;
                    totalSpent += 0;
                    Console.WriteLine("Too Expensive");
                }

                if (gameName != "OutFall 4" && gameName != "CS: OG" && gameName != "Zplinter Zell" && gameName != "Honored 2" && gameName != "RoverWatch" && gameName != "RoverWatch Origins Edition")
                {
                    Console.WriteLine("Not Found");
                }

                if (currentBalance <= 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }

                gameName = Console.ReadLine();
            }
            if (currentBalance > 0)
            {
                Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${currentBalance:f2}");
            }
        }
    }
}
