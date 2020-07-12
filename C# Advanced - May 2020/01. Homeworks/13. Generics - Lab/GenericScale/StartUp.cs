using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> scale1 = new EqualityScale<int>(6, 5);
            Console.WriteLine(scale1.AreEqual());

            EqualityScale<string> scale2 = new EqualityScale<string>("bla", "la");
            Console.WriteLine(scale2.AreEqual());

            EqualityScale<int[]> scale3 = new EqualityScale<int[]>(new int[] { 1, 2 ,3 }, new int[] { 1, 2, 3 });
            Console.WriteLine(scale3.AreEqual());
        }
    }
}
