using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string coins = Console.ReadLine();
            double totalMoneyInserted = 0;
            double productPrice = 0;
            string product = "";

            while (coins != "Start")
            {
                if (double.Parse(coins) != 0.1 && double.Parse(coins) != 0.2 && double.Parse(coins) != 0.5 && double.Parse(coins) != 1 && double.Parse(coins) != 2)
                {
                    Console.WriteLine($"Cannot accept {coins}");
                    totalMoneyInserted += 0;
                }

                else
                {
                    totalMoneyInserted += double.Parse(coins);
                }

                coins = Console.ReadLine();
            }

            if (coins == "Start")
            {
                product = Console.ReadLine();

                while (product != "End")
                {
                    if (product != "Nuts" && product != "Water" && product != "Crisps" && product != "Soda" && product != "Coke")
                    {
                        Console.WriteLine("Invalid product");
                    }

                    productPrice = 0;

                    if (product == "Nuts")
                    {
                        productPrice += 2.0;

                        if (productPrice > totalMoneyInserted)
                        {
                            totalMoneyInserted = totalMoneyInserted;
                            Console.WriteLine("Sorry, not enough money");
                        }

                        else
                        {
                            totalMoneyInserted -= productPrice;
                            Console.WriteLine($"Purchased nuts");
                        }
                    }

                    if (product == "Water")
                    {
                        productPrice += 0.7;

                        if (productPrice > totalMoneyInserted)
                        {
                            totalMoneyInserted = totalMoneyInserted;
                            Console.WriteLine("Sorry, not enough money");
                        }

                        else
                        {
                            totalMoneyInserted -= productPrice;
                            Console.WriteLine($"Purchased water");
                        }
                    }

                    if (product == "Crisps")
                    {
                        productPrice += 1.5;

                        if (productPrice > totalMoneyInserted)
                        {
                            totalMoneyInserted = totalMoneyInserted;
                            Console.WriteLine("Sorry, not enough money");
                        }

                        else
                        {
                            totalMoneyInserted -= productPrice;
                            Console.WriteLine($"Purchased crisps");
                        }
                    }

                    if (product == "Soda")
                    {
                        productPrice += 0.8;

                        if (productPrice > totalMoneyInserted)
                        {
                            totalMoneyInserted = totalMoneyInserted;
                            Console.WriteLine("Sorry, not enough money");
                        }

                        else
                        {
                            totalMoneyInserted -= productPrice;
                            Console.WriteLine($"Purchased soda");
                        }
                    }

                    if (product == "Coke")
                    {
                        productPrice += 1.0;

                        if (productPrice > totalMoneyInserted)
                        {
                            totalMoneyInserted = totalMoneyInserted;
                            Console.WriteLine("Sorry, not enough money");
                        }

                        else
                        {
                            totalMoneyInserted -= productPrice;
                            Console.WriteLine($"Purchased coke");
                        }
                    }

                    product = Console.ReadLine();
                }
            }

            if (product == "End")
            {
                Console.WriteLine($"Change: {totalMoneyInserted:f2}");
            }
        }
    }
}
