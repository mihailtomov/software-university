using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commands
{
    public class ByeCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Bye, {args[0]}";
        }
    }
}
