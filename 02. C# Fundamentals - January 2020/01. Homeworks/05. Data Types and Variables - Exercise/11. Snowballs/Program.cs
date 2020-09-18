using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSnowballs = int.Parse(Console.ReadLine());
            BigInteger highestSnowballValue = 0;
            int highestSnowballSnow = 0;
            int highestsnowballTime = 0;
            int highestsnowballQuality = 0;

            for (int i = 0; i < numberOfSnowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                BigInteger snowballValue = ValueCalculatedByFormula(snowballSnow, snowballTime, snowballQuality);

                if (snowballValue > highestSnowballValue)
                {
                    highestSnowballValue = snowballValue;
                    highestSnowballSnow = snowballSnow;
                    highestsnowballTime = snowballTime;
                    highestsnowballQuality = snowballQuality;
                }
            }

            Console.WriteLine($"{highestSnowballSnow} : {highestsnowballTime} = {highestSnowballValue} ({highestsnowballQuality})");
        }

        private static BigInteger ValueCalculatedByFormula(int snowballSnow, int snowballTime, int snowballQuality)
        {
            BigInteger snowballValue = 0;

            int baseNum = snowballSnow / snowballTime;
            BigInteger currNum = baseNum;

            if (snowballQuality == 0)
            {
                snowballValue = 1;
            }

            else if (snowballQuality == 1)
            {
                snowballValue = baseNum;
            }

            else
            {
                for (int j = 0; j < snowballQuality - 1; j++)
                {
                    snowballValue = currNum * baseNum;
                    currNum = snowballValue;
                }
            }

            return snowballValue;
        }
    }
}
