using P03Raiding.Factories;
using System;
using System.Collections.Generic;

namespace P03Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> raidGroup = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                HeroFactory factory = null;

                switch (heroType)
                {
                    case "Druid": factory = new DruidFactory(heroName);
                        break;
                    case "Paladin": factory = new PaladinFactory(heroName);
                        break;
                    case "Rogue": factory = new RogueFactory(heroName);
                        break;
                    case "Warrior": factory = new WarriorFactory(heroName);
                        break;
                    default: Console.WriteLine("Invalid hero!");
                        i--;
                        break;
                }

                if (factory != null)
                {
                    raidGroup.Add(factory.CreateHero());
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            int totalPower = 0;

            foreach (var hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
                totalPower += hero.Power;
            }

            if (totalPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
