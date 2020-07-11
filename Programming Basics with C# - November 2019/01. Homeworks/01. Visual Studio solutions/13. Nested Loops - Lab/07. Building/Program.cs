using System;

namespace _07._Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int roomsPerFloor = int.Parse(Console.ReadLine());

            for (int descendingFloor = floors; descendingFloor > 0; descendingFloor--)
            {
                for (int roomNumber = 0; roomNumber < roomsPerFloor; roomNumber++)
                {
                    if (descendingFloor == floors || floors == 1)
                    {
                       Console.Write($"L{descendingFloor}{roomNumber} ");
                    }
                    else if (descendingFloor % 2 == 0)
                    {
                        Console.Write($"O{descendingFloor}{roomNumber} ");
                    }

                    else
                    {
                        Console.Write($"A{descendingFloor}{roomNumber} ");
  
                    }

                }

                Console.WriteLine();
            }
        }
    }
}
