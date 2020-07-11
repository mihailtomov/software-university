using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int h = 0; h < 24; h++)
            {               
                for (int m = 0; m < 60; m++)
                {
                    for (int s = 0; s < 60; s++)
                    {
                        System.Threading.Thread.Sleep(1000); // pravi pauza ot milisekundi predi izpulnqvane, v sluchaq 1000ms = 1 sekunda
                        Console.SetCursorPosition(0, 0); // vmesto na nov red, izpisva koda na dadena poziciq na edno i sushto mqsto
                        Console.WriteLine($"{h:d2}:{m:d2}:{s:d2}");
                    }
                }
            }

            //za edna iteraciq na vunshniq se izpulnqvat vsichki iteracii na vutreshniq
        }
    }
}
