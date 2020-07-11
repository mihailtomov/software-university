using System;
using System.Text;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string bigNum = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();

            int leftOver = 0;

            if (bigNum.Length > 1 && bigNum[0] == '0')
            {
                int lastIndex = bigNum.LastIndexOf('0');
                bigNum = bigNum.Substring(lastIndex);
            }

            for (int i = bigNum.Length - 1; i >= 0; i--)
            {
                int tempNum = 0;
                int currNum = int.Parse(bigNum[i].ToString());

                tempNum = (currNum * multiplier) + leftOver;

                leftOver = 0;

                string temp = tempNum.ToString();

                char[] tempArgs = temp.ToCharArray();

                if (tempArgs.Length > 1 && i != 0)
                {
                    result.Insert(0, tempArgs[1]);
                    leftOver += int.Parse(tempArgs[0].ToString());
                }

                else
                {
                    result.Insert(0, temp);
                }
            }

            if (multiplier != 0)
            {
                Console.WriteLine(result);
            }


            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
