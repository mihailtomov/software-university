using System;

namespace P03Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var sites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < numbers.Length; i++)
            {
                string number = numbers[i];

                if (number.Length == 7)
                {
                    new StationaryPhone().Call(number);
                }
                else
                {
                    new Smartphone().Call(number);
                }
            }

            for (int i = 0; i < sites.Length; i++)
            {
                string site = sites[i];
                new Smartphone().Browse(site);
            }
        }
    }
}
