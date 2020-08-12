using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double savedMoney = double.Parse(Console.ReadLine());

            while (savedMoney < moneyNeeded)
            {
                string action = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());

                if (action == "spend")
                {
                    if (money > savedMoney)
                    {
                        money = 0;
                    }
                    savedMoney -= money;
                }
                else if (action == "save")
                {
                    savedMoney += money;
                }
            }
        }
    }
}
