using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int bakers = int.Parse(Console.ReadLine());
            int numOfCakes = int.Parse(Console.ReadLine());
            int numOfWaffles = int.Parse(Console.ReadLine());
            int numOfPancakes = int.Parse(Console.ReadLine());

            // 1. calculate profit

            double cakesProfit = numOfCakes * 45;
            double wafflesProfit = numOfWaffles * 5.80;
            double pancakesProfit = numOfPancakes * 3.20;

            double totalPrice = (cakesProfit + wafflesProfit + pancakesProfit) * bakers;
            Console.WriteLine(totalPrice);
        }
    }
}
