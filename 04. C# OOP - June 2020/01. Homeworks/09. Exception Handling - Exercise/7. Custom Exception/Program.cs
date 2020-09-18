using System;

namespace _7._Custom_Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student student = new Student("Gin4o", "gin4o@gin4o.bg");
            }
            catch (InvalidPersonNameException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
