using System.Linq;

namespace P03Telephony
{
    public class StationaryPhone : IStationaryPhone
    {
        public void Call(string number)
        {
            if (number.All(char.IsDigit))
            {
                System.Console.WriteLine($"Dialing... {number}");
            }
            else
            {
                System.Console.WriteLine("Invalid number!");
            }
        }
    }
}