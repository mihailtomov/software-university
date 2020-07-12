using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();
            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] splitArgs = command.Split(", ");
                string direction = splitArgs[0];
                string carNumber = splitArgs[1];

                if (direction == "IN")
                {
                    carNumbers.Add(carNumber);
                }
                else
                {
                    carNumbers.Remove(carNumber);
                }
            }

            if (carNumbers.Count > 0)
            {
                foreach (string carNumber in carNumbers)
                {
                    Console.WriteLine(carNumber);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
