using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commands
{
    public class SleepCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Goodnight {args[0]}";
        }
    }
}
