using System;

namespace _05._Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int mainDigit = int.Parse(Console.ReadLine());
            string input = string.Empty;

            for (int i = 0; i < mainDigit; i++)
            {
                string numberOfDigits = Console.ReadLine();

                int numberLength = numberOfDigits.Length;
                int main = numberOfDigits[0] - '0';
                int offset = (main - 2) * 3;

                if (main == 8 || main == 9)
                {
                    offset++;
                }

                int letterIndex = offset + numberLength - 1;

                if (main != 0)
                {
                    input += (char)(letterIndex + 97);
                }
                else
                {
                    input += " ";
                }
            }

            Console.WriteLine(input);
        }
    }
}
