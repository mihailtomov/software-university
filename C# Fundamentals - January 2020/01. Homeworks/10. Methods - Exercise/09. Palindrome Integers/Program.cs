using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        public static void Main(string[] args)
        {
            string num = Console.ReadLine();

            IfNumIsPalindrome(num);
        }

        static void IfNumIsPalindrome(string num)
        {
            while (num != "END")
            {
                if (num == NumBackward(num))
                {
                    Console.WriteLine("true");
                }

                else
                {
                    Console.WriteLine("false");
                }

                num = Console.ReadLine();
            }
        }

        static string NumBackward(string num)
        {
            string backward = "";
            for (int i = num.Length - 1; i >= 0; i--)
            {
                backward += num[i];
            }

            return backward;
        }
    }
}
