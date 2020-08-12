using System;

namespace _08._Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = "";

            double studentTicketCount = 0;
            double standardTicketCount = 0;
            double kidTicketCount = 0;
            double currentTicketsCount = 0;
            double totalTicketsCount = 0;

            bool isFinish = false;

            while (movieName != "Finish")
            {
                movieName = Console.ReadLine();

                if (movieName == "Finish")
                {
                    isFinish = true;
                    break;
                }

                double availableSeats = double.Parse(Console.ReadLine());

                for (int i = 0; i < availableSeats; i++)
                {
                    string ticketType = Console.ReadLine();

                    if (ticketType == "End")
                    {
                        break;
                    }

                    currentTicketsCount++;
                    totalTicketsCount++;

                    switch (ticketType)
                    {
                        case "student":
                            studentTicketCount++;
                            break;
                        case "standard":
                            standardTicketCount++;
                            break;
                        case "kid":
                            kidTicketCount++;
                            break;
                    }

                }

                double currentPercent = currentTicketsCount / availableSeats * 100;

                Console.WriteLine($"{movieName} - {currentPercent:f2}% full.");
                currentTicketsCount = 0;
            }

            double studentPercent = studentTicketCount / totalTicketsCount * 100;
            double standardPercent = standardTicketCount / totalTicketsCount * 100;
            double kidPercent = kidTicketCount / totalTicketsCount * 100;

            if (isFinish)
            {
                Console.WriteLine($"Total tickets: {totalTicketsCount}");
                Console.WriteLine($"{studentPercent:f2}% student tickets.");
                Console.WriteLine($"{standardPercent:f2}% standard tickets.");
                Console.WriteLine($"{kidPercent:f2}% kids tickets.");
            }
        }
    }
}
