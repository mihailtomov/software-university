using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 12; i++)
            {
                Console.WriteLine(i);
            }

            // for, kogato znaem tochno kolko puti shte se povtori uslovieto

            // while, kogato ne sme sigurni kolko puti shte se povtori uslovieto

            int i = 1;

            while (i <= 12)
            {
                Console.WriteLine(i);
                i++;               
            }
        }
    }
}
