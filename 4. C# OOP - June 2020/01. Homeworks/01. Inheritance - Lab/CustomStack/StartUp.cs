using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings(new string[] { "misho", "pesho", "gosho"});
            Console.WriteLine(stack.IsEmpty());
            stack.AddRange(new string[] { "oshte", "imena" });
            Console.WriteLine(string.Join(" ", stack));
        }
    }
}
