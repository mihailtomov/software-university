using System;

namespace Pregovor
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int sum = 0;

            while (input != "Stop")
            {
                if (input == "5")
                {
                    input = Console.ReadLine();
                    continue;
                }

                sum += int.Parse(input);
                input = Console.ReadLine();
            }

            Console.WriteLine(sum);


            // loops

            // endless loops

            // break/continue
        }
    }
}
