using System;

namespace Pregovor
{
    class Program
    {
        static void Main(string[] args)
        {
            // boolean


            // if ... else


            // if ... else if

            
            // variable life

            // debugging

            

            // && - and
            // || - or
            // != - negation


            //switch (only when checking ==)
            string weather = Console.ReadLine();

            switch (weather)
            {
                case "sunny":
                    Console.WriteLine("Go outside!");
                    break;
                case "rainy":
                    Console.WriteLine("Take an umbrella!");
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}
