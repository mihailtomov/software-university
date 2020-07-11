using System;

namespace _06._Christmas_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int tournamentDaysCount = int.Parse(Console.ReadLine());

            double moneyWon = 0;
            double winCount = 0;
            double loseCount = 0;
            double dayWinCount = 0;
            double dayLoseCount = 0;
            double currentMoneyWon = 0;

            for (int i = 0; i < tournamentDaysCount; i++)
            {
                string sportType = Console.ReadLine();

                currentMoneyWon = 0;
                winCount = 0;
                loseCount = 0;

                while (sportType != "Finish")
                {
                    string result = Console.ReadLine();

                    if (result == "win")
                    {
                        currentMoneyWon += 20;
                        winCount++;
                    }

                    if (result == "lose")
                    {
                        loseCount++;
                    }

                    sportType = Console.ReadLine();
                }

                if (winCount > loseCount)
                {
                    currentMoneyWon += 0.10 * currentMoneyWon;
                    dayWinCount++;
                }

                else
                {
                    dayLoseCount++;
                }

                moneyWon += currentMoneyWon;
            }

            if (dayLoseCount > dayWinCount)
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {moneyWon:f2}");
            }

            if (dayWinCount > dayLoseCount)
            {
                moneyWon += 0.20 * moneyWon;
                Console.WriteLine($"You won the tournament! Total raised money: {moneyWon:f2}");
            }
        }
    }
}
