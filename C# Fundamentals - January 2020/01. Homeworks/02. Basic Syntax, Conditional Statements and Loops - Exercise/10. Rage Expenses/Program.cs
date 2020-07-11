using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double totalExpenses = 0.0;
            int keyboardCounter = 0;

            for (int i = 1; i <= lostGamesCount; i++)
            {
                if (i % 2 == 0)
                {
                    totalExpenses += headsetPrice;
                }

                if (i % 3 == 0)
                {
                    totalExpenses += mousePrice;
                }

                if (i % 2 == 0 && i % 3 == 0)
                {
                    totalExpenses += keyboardPrice;
                    keyboardCounter++;

                    if (keyboardCounter == 2)
                    {
                        totalExpenses += displayPrice;
                        keyboardCounter = 0;
                    }
                }
            }
            Console.WriteLine($"Rage expenses: {totalExpenses:f2} lv.");
        }
    }
}
