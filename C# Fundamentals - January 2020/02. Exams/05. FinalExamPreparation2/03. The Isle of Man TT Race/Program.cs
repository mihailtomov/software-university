using System;
using System.Text.RegularExpressions;

namespace _03._The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([#$%*&])(?<racer>[A-Za-z]+)\1=(?<length>[\d]+)!!(?<geohash>.+)";

            while (true)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    int length = int.Parse(match.Groups["length"].Value);
                    int hashLength = match.Groups["geohash"].Value.Length;

                    if (length == hashLength)
                    {
                        string nameOfRacer = match.Groups["racer"].Value;
                        string geohash = match.Groups["geohash"].Value;
                        string decryptedCode = "";

                        for (int i = 0; i < geohash.Length; i++)
                        {
                            int currCh = geohash[i];
                            decryptedCode += (char)(currCh + length);
                        }

                        Console.WriteLine($"Coordinates found! {nameOfRacer} -> {decryptedCode}");
                        break;
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
