using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(", ");

            Dictionary<string, int> participants = new Dictionary<string, int>();

            for (int i = 0; i < names.Length; i++)
            {
                string currName = names[i];
                if (!participants.ContainsKey(currName))
                {
                    participants[currName] = 0;
                }
            }

            string input;

            while ((input = Console.ReadLine()) != "end of race")
            {
                string currName = "";
                int currSum = 0;

                foreach (char ch in input)
                {
                    if (Char.IsLetter(ch))
                    {
                        currName += ch;
                    }

                    if (Char.IsNumber(ch))
                    {
                        currSum += int.Parse(ch.ToString());
                    }
                }

                if (participants.ContainsKey(currName))
                {
                    participants[currName] += currSum;
                }
            }

            participants = participants
            .OrderByDescending(pair => pair.Value)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

            List<string> topFinishers = new List<string>();

            int counter = 1;

            foreach (var kvp in participants)
            {
                if (counter <= 3)
                {
                    topFinishers.Add(kvp.Key);
                }

                counter++;
            }

            Console.WriteLine($"1st place: {topFinishers[0]}");
            Console.WriteLine($"2nd place: {topFinishers[1]}");
            Console.WriteLine($"3rd place: {topFinishers[2]}");
        }
    }
}
