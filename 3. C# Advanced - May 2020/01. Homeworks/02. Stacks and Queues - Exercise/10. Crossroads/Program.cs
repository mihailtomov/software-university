using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int totalCarsPassed = 0;

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                if (!command.Contains("green"))
                {
                    string carToAdd = command;
                    cars.Enqueue(carToAdd);                  
                }
                else
                {
                    if (cars.Any())
                    {
                        string currCar = cars.Peek();
                        string carToPrint = cars.Peek();

                        for (int i = 1; i <= greenLightSeconds + freeWindowSeconds; i++)
                        {
                            currCar = currCar.Remove(0, 1);

                            if (currCar.Length == 0)
                            {
                                cars.Dequeue();
                                totalCarsPassed++;

                                if (cars.Any() && i < greenLightSeconds)
                                {
                                    currCar = cars.Peek();
                                    carToPrint = cars.Peek();
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }

                        if (currCar.Length > 0)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{carToPrint} was hit at {currCar[0]}.");
                            return;
                        }
                    }                   
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }
    }
}
