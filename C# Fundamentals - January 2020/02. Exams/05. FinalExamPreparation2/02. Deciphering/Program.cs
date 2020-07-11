using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            string textToDecipher = Console.ReadLine();
            string textToReplace = Console.ReadLine();

            string pattern = @"^[^abc]*[{}|#]*$";

            Match match = Regex.Match(textToDecipher, pattern);

            if (!match.Success)
            {
                Console.WriteLine("This is not the book you are looking for.");
            }
            else
            {
                StringBuilder decipheredText = new StringBuilder();

                for (int i = 0; i < textToDecipher.Length; i++)
                {
                    int currCh = textToDecipher[i];
                    currCh -= 3;
                    decipheredText.Append((char)currCh);
                }

                string[] wordsToReplace = textToReplace.Split();
                string firstWord = wordsToReplace[0];
                string secondWord = wordsToReplace[1];

                decipheredText = decipheredText.Replace(firstWord, secondWord);
                Console.WriteLine(decipheredText);
            }
        }
    }
}
