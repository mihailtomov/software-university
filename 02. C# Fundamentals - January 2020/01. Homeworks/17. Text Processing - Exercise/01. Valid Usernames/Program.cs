using System;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");

            foreach (string name in usernames)
            {
                bool isValid = true;

                for (int i = 0; i < name.Length; i++)
                {
                    char currChar = name[i];

                    if (!char.IsLetterOrDigit(currChar) && currChar != '-' && currChar != '_')
                    {
                        isValid = false;
                    }
                }

                if (isValid == true && name.Length >= 3 && name.Length <= 16)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
