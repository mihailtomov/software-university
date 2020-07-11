using System;
using System.Text.RegularExpressions;

namespace _01._Arriving_in_Kathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(?<peak>[A-Za-z0-9!@#$?]+)=(?<length>\d+)<<(?<hash>.+)$";

            string input;

            while ((input = Console.ReadLine()) != "Last note")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    int length = int.Parse(match.Groups["length"].Value);
                    int hashLength = match.Groups["hash"].Value.Length;

                    if (length == hashLength)
                    {
                        string peakCode = match.Groups["peak"].Value;
                        string geoCode = match.Groups["hash"].Value;

                        string nameOfMountain = "";

                        for (int i = 0; i < peakCode.Length; i++)
                        {
                            char currCh = peakCode[i];

                            if (Char.IsLetterOrDigit(currCh))
                            {
                                nameOfMountain += currCh;
                            }
                        }
                        Console.WriteLine($"Coordinates found! {nameOfMountain} -> {geoCode}");
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}
