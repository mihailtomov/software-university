using System;

namespace _5._Convert.ToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] examples = new string[] {"dasdsa", "1.....31231...,,", "-1,035.77219", "1AFF", "1e-35",
                         "1,635,592,999,999,999,999,999,999", "-17.455",
                         "190.34001", "1.29e325"};
            double result;

            foreach (string example in examples)
            {
                try
                {
                    result = Convert.ToDouble(example);
                    Console.WriteLine(result);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }
        }
    }
}
