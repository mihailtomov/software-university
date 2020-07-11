using System;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();

            string allDigits = "";
            string allLetters = "";
            string allOtherCharacters = "";

            foreach (char symbol in text)
            {
                if (char.IsDigit(symbol))
                {
                    allDigits += symbol;
                }

                else if (char.IsLetter(symbol))
                {
                    allLetters += symbol;
                }

                else
                {
                    allOtherCharacters += symbol;
                }
            }

            Console.WriteLine(allDigits);
            Console.WriteLine(allLetters);
            Console.WriteLine(allOtherCharacters);
        }
    }
}
