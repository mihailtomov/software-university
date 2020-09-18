using System;

namespace _01._Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            int wonBattlesCount = 0;
            string input;

            while ((input = Console.ReadLine()) != "End of battle")
            {
                int currentDistance = int.Parse(input);

                if (currentDistance > initialEnergy)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wonBattlesCount} won battles and {initialEnergy} energy");
                    return;
                }

                initialEnergy -= currentDistance;
                wonBattlesCount++;

                if (wonBattlesCount % 3 == 0)
                {
                    initialEnergy += wonBattlesCount;
                }
            }

            Console.WriteLine($"Won battles: {wonBattlesCount}. Energy left: {initialEnergy}");
        }
    }
}
