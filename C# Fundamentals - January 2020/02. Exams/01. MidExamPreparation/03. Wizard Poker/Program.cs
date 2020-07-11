using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Wizard_Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            //listname.IndexOf(element name) proverqva dali daden element sushtestvuva v lista i vrushta negoviq index, ako ne - izliza -1
            //Array.IndexOf(masiv, elementa) kogato e za masivi, proverqva dali chast ot elementa sushtestvuva (kude e nachaloto na imeto na elementa koito tursim)

            List<string> availableDeck = Console.ReadLine().Split(':').ToList();
            string command = Console.ReadLine();

            List<string> newDeck = new List<string>();

            while (command != "Ready")
            {
                string[] splitted = command.Split();

                if (splitted[0] == "Add")
                {
                    string cardName = splitted[1];

                    if (availableDeck.Contains(cardName))
                    {
                        newDeck.Add(cardName);
                    }

                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }

                if (splitted[0] == "Insert")
                {
                    string cardName = splitted[1];
                    int index = int.Parse(splitted[2]);

                    if (!availableDeck.Contains(cardName) || index < 0 || index > newDeck.Count)
                    {
                        Console.WriteLine("Error!");
                    }

                    else
                    {
                        newDeck.Insert(index, cardName);
                    }
                }

                if (splitted[0] == "Remove")
                {
                    string cardName = splitted[1];

                    if (newDeck.Contains(cardName))
                    {
                        newDeck.Remove(cardName);
                    }

                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }

                if (splitted[0] == "Swap")
                {
                    string cardName1 = splitted[1];
                    string cardName2 = splitted[2];

                    int firstIndex = newDeck.IndexOf(cardName1);
                    int secondIndex = newDeck.IndexOf(cardName2);

                    string temp = newDeck[firstIndex];
                    newDeck[firstIndex] = newDeck[secondIndex];
                    newDeck[secondIndex] = temp;
                }

                if (splitted[0] == "Shuffle")
                {
                    newDeck.Reverse();
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", newDeck));
        }
    }
}
