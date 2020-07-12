using System;
using System.Collections.Generic;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> dict = 
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = data[0];
                string country = data[1];
                string city = data[2];

                if (!dict.ContainsKey(continent))
                {
                    dict[continent] = new Dictionary<string, List<string>>();

                    if (!dict[continent].ContainsKey(country))
                    {
                        dict[continent][country] = new List<string>() {city};
                    }
                    else
                    {
                        dict[continent][country].Add(city);
                    }
                }
                else
                {
                    if (!dict[continent].ContainsKey(country))
                    {
                        dict[continent][country] = new List<string>() { city };
                    }
                    else
                    {
                        dict[continent][country].Add(city);
                    }
                }
            }

            foreach (var kvp in dict)
            {
                string continent = kvp.Key;
                Dictionary<string, List<string>> countries = kvp.Value;

                Console.WriteLine($"{continent}:");

                foreach (var country in countries)
                {
                    string currCountry = country.Key;
                    List<string> cities = country.Value;

                    Console.WriteLine($"  {currCountry} -> {string.Join(", ", cities)}");
                }
            }
        }
    }
}
