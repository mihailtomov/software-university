using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePowerN = int.Parse(Console.ReadLine());
            int distanceBetweenTargetsM = int.Parse(Console.ReadLine());
            int exhaustionFactorY = int.Parse(Console.ReadLine());

            int pokedTargetsCount = 0;
            int pokePowerHalf = pokePowerN / 2;

            while (pokePowerN >= distanceBetweenTargetsM)
            {
                pokePowerN -= distanceBetweenTargetsM;

                if (pokePowerN == pokePowerHalf)
                {
                    if (exhaustionFactorY != 0)
                    {
                        pokePowerN /= exhaustionFactorY;
                    }

                    else
                    {
                        continue;
                    }
                }

                pokedTargetsCount++;
            }

            Console.WriteLine(pokePowerN);
            Console.WriteLine(pokedTargetsCount);
        }
    }
}
