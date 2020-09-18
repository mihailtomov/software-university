using System.Linq;

namespace P03Telephony
{
    public class Smartphone : ISmartphone
    {
        public void Browse(string site)
        {
            if (!site.Any(char.IsDigit))
            {
                System.Console.WriteLine($"Browsing: {site}!");
            }
            else
            {
                System.Console.WriteLine("Invalid URL!");
            }
        }

        public void Call(string number)
        {
            if (number.All(char.IsDigit))
            {
                System.Console.WriteLine($"Calling... {number}");
            }
            else
            {
                System.Console.WriteLine("Invalid number!");
            }
        }
    }
}