using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal groupCount = decimal.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            decimal totalPrice = 0;

            if (dayOfWeek == "Friday")
            {
                if (groupType == "Students")
                {
                    totalPrice = 8.45M * groupCount;
                }

                if (groupType == "Business")
                {
                    totalPrice = 10.90M * groupCount;
                }

                if (groupType == "Regular")
                {
                    totalPrice = 15 * groupCount;
                }
            }

            if (dayOfWeek == "Saturday")
            {
                if (groupType == "Students")
                {
                    totalPrice = 9.80M * groupCount;
                }

                if (groupType == "Business")
                {
                    totalPrice = 15.60M * groupCount;
                }

                if (groupType == "Regular")
                {
                    totalPrice = 20 * groupCount;
                }
            }

            if (dayOfWeek == "Sunday")
            {
                if (groupType == "Students")
                {
                    totalPrice = 10.46M * groupCount;
                }

                if (groupType == "Business")
                {
                    totalPrice = 16 * groupCount;
                }

                if (groupType == "Regular")
                {
                    totalPrice = 22.50M * groupCount;
                }
            }

            decimal stayForFree = totalPrice / groupCount * 10;

            if (groupCount >= 30 && groupType == "Students")
            {
                totalPrice = 0.85M * totalPrice;
            }

            if (groupCount >= 100 && groupType == "Business")
            {
                totalPrice = totalPrice - stayForFree;
            }

            if (groupCount >= 10 && groupCount <= 20 && groupType == "Regular")
            {
                totalPrice = 0.95M * totalPrice;
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
