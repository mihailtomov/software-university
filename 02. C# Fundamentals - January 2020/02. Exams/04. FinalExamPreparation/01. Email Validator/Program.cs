using System;
using System.Text;

namespace _01._Email_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();

            string command;

            while ((command = Console.ReadLine()) != "Complete")
            {
                string[] splitArgs = command.Split();

                if (command.Contains("Make Upper"))
                {
                    email = email.ToUpper();
                    Console.WriteLine(email);
                }

                if (command.Contains("Make Lower"))
                {
                    email = email.ToLower();
                    Console.WriteLine(email);
                }

                if (command.Contains("GetDomain"))
                {
                    int count = int.Parse(splitArgs[1]);
                    Console.WriteLine($"{email.Substring(email.Length - count, count)}");
                }

                if (command.Contains("GetUsername"))
                {
                    if (email.Contains("@"))
                    {
                        int indexOfSymbol = email.IndexOf("@");
                        Console.WriteLine($"{email.Substring(0, indexOfSymbol)}");
                    }
                    else
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                }

                if (command.Contains("Replace"))
                {
                    char chToReplace = char.Parse(splitArgs[1]);

                    if (email.Contains(chToReplace))
                    {
                        email = email.Replace(chToReplace, '-');
                    }

                    Console.WriteLine(email);
                }

                if (command.Contains("Encrypt"))
                {
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < email.Length; i++)
                    {
                        sb.Append((int)email[i]);
                        sb.Append(' ');
                    }

                    Console.WriteLine(sb);
                }
            }
        }
    }
}
