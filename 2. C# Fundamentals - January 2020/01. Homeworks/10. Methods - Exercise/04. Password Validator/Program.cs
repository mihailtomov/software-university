using System;

namespace _04._Password_Validator
{
    class Program
    {
        public static void Main(string[] args)
        {
            string password = Console.ReadLine();

            if (IsBetweenSixAndTenCharacters(password) && OnlyLettersAndDigits(password) && HaveAtLeastTwoDigits(password))
            {
                Console.WriteLine("Password is valid");
            }

            if (!IsBetweenSixAndTenCharacters(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!OnlyLettersAndDigits(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!HaveAtLeastTwoDigits(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }

        static bool IsBetweenSixAndTenCharacters(string password)
        {
            bool isValid = false;

            if (password.Length - 1 >= 6 && password.Length - 1 <= 10)
            {
                isValid = true;
            }

            return isValid;
        }

        static bool OnlyLettersAndDigits(string password)
        {
            foreach (char currChar in password)
            {
                if (!Char.IsLetterOrDigit(currChar))
                {
                    return false;
                }
            }

            return true;
        }

        static bool HaveAtLeastTwoDigits(string password)
        {
            int digitsCount = 0;
            bool isValid = false;

            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 48 && password[i] <= 57)
                {
                    digitsCount++;
                }
            }

            if (digitsCount >= 2)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
