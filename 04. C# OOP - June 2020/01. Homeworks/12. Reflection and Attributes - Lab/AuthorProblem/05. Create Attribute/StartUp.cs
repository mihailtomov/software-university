using System;
using System.Reflection;

namespace AuthorProblem
{
    [Author("Ventsi")]
    public class StartUp
    {
        [Author("Gosho")]
        static void Main(string[] args)
        {
            Type type = typeof(StartUp);
            MethodInfo main = type.GetMethod("Main", BindingFlags.Static | BindingFlags.NonPublic);
            ;
        }
    }
}
