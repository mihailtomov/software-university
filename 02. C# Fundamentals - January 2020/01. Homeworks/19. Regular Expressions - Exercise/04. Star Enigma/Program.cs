using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string decrypt = @"[starSTAR]";
            string data = @"[^@\-!:>]*?@([A-Za-z]+)[^@\-!:>]*?:(\d+)[^@\-!:>]*?!(A|D)![^@\-!:>]*?->(\d+)[^@\-!:>]*?";

            Regex regex1 = new Regex(decrypt);
            Regex regex2 = new Regex(data);

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string encryptedMessage = Console.ReadLine();

                MatchCollection matches = regex1.Matches(encryptedMessage);

                int count = matches.Count;
                string decrypted = "";

                for (int j = 0; j < encryptedMessage.Length; j++)
                {
                    decrypted += (char)(encryptedMessage[j] - count);
                }

                Match match = regex2.Match(decrypted);

                string planetName = match.Groups[1].ToString();
                string attackType = match.Groups[3].ToString();

                if (attackType == "A")
                {
                    attackedPlanets.Add(planetName);
                }

                if (attackType == "D")
                {
                    destroyedPlanets.Add(planetName);
                }
            }

            attackedPlanets = attackedPlanets.OrderBy(l => l).ToList();
            destroyedPlanets = destroyedPlanets.OrderBy(l => l).ToList();

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (string planet in attackedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (string planet in destroyedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
