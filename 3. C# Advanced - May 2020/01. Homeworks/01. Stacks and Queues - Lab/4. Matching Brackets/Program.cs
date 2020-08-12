using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> openingIndex = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    openingIndex.Push(i);
                }

                if (expression[i] == ')')
                {
                    int startIndex = openingIndex.Pop();
                    int endIndex = i;

                    string subExpression = expression.Substring(startIndex, endIndex - startIndex + 1);
                    Console.WriteLine(subExpression);
                }
            }
        }
    }
}
