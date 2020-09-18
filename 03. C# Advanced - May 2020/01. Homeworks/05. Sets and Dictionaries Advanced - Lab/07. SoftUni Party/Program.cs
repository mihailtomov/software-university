using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regulars = new HashSet<string>();
            HashSet<string> vips = new HashSet<string>();

            string input;

            while (true)
            {
                input = Console.ReadLine();

                if (input == "END" || input == "PARTY")
                {
                    break;
                }

                if (Char.IsDigit(input[0]))
                {
                    vips.Add(input);
                }
                else
                {
                    regulars.Add(input);
                }              
            }

            if (input == "PARTY")
            {
                while (input != "END")
                {
                    input = Console.ReadLine();

                    if (Char.IsDigit(input[0]))
                    {
                        vips.Remove(input);
                    }
                    else
                    {
                        regulars.Remove(input);
                    }
                }
            }

            Console.WriteLine(vips.Count + regulars.Count);

            foreach (string vip in vips)
            {
                Console.WriteLine(vip);
            }
            foreach (string regular in regulars)
            {
                Console.WriteLine(regular);
            }
        }
    }
}
