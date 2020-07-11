using System;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([@][#]+)(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])([@][#]+)";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string barcode = match.Groups["barcode"].Value;

                    string productGroup = "00";

                    int counter = 0;

                    for (int j = 0; j < barcode.Length; j++)
                    {
                        char currCh = barcode[j];

                        if (Char.IsDigit(currCh))
                        {
                            counter++;
                            if (counter == 1)
                            {
                                productGroup = "";
                            }
                            productGroup += currCh;
                        }
                    }

                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
