using System;

namespace Practice_For_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();

            for (int i = n.Length - 1; i >= 0; i--)
            {
                char currentNum = n[i];
                string toStringNum = currentNum.ToString();
                int intCurrentNum = int.Parse(toStringNum);

                if (intCurrentNum == 0)
                {
                    Console.Write("ZERO");
                }

                for (int j = 0; j < intCurrentNum; j++)
                {
                    char currentSymbol = (char)(intCurrentNum + 33);
                    Console.Write(currentSymbol);
                }

                Console.WriteLine();
            }
        }
    }
}
