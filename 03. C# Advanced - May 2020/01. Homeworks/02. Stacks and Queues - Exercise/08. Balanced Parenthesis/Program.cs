using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> openParenthesis = new Stack<char>();
            bool isExpressionBalanced = true;

            foreach (char c in input)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    openParenthesis.Push(c);
                }
                else
                {
                    if (!openParenthesis.Any())
                    {
                        isExpressionBalanced = false;
                        break;
                    }

                    char currOpenParenthesis = openParenthesis.Pop();

                    bool isOpenBalanced = currOpenParenthesis == '(' && c == ')';
                    bool isCurlyBalanced = currOpenParenthesis == '{' && c == '}';
                    bool isSquareBalanced = currOpenParenthesis == '[' && c == ']';

                    if (isOpenBalanced == false && isCurlyBalanced == false && isSquareBalanced == false)
                    {
                        isExpressionBalanced = false;
                    }
                }
            }

            if (isExpressionBalanced == true)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
