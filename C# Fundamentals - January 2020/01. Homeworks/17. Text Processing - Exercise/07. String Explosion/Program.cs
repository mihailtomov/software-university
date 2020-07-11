using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int bonusStrength = 0;

            for (int i = 0; i < input.Length - 1; i++)
            {
                char currCh = input[i];
                char nextCh = input[i + 1];

                int strength = 0;
                int indexToRemove = 0;
                
                if (currCh == '>')
                {
                    strength = int.Parse(nextCh.ToString()) + bonusStrength;

                    bonusStrength = 0;
                    indexToRemove = i + 1;

                    int counter = 0;

                    int removingThreshold = 0;

                    for (int j = indexToRemove; j < input.Length; j++)
                    {
                        if (input[j] != '>')
                        {
                            removingThreshold++;
                        }

                        else
                        {
                            break;
                        }
                    }

                    if (strength + indexToRemove <= input.Length || indexToRemove + removingThreshold < input.Length)
                    {
                        for (int k = 0; k < strength; k++)
                        {
                            if (input[indexToRemove] != '>')
                            {
                                input = input.Remove(indexToRemove, 1);
                                counter++;
                            }

                            else
                            {
                                bonusStrength = strength - counter;
                                break;
                            }
                        }
                    }                   
                }    
            }

            Console.WriteLine(input);
        }
    }
}
