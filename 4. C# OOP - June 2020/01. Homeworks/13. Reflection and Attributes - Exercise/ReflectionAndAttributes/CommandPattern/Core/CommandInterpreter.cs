using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split();
            string commandName = tokens[0] + "Command";

            Type commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == commandName);

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            ICommand command = Activator.CreateInstance(commandType) as ICommand;

            string[] targetData = tokens.Skip(1).ToArray();
            return command.Execute(targetData);
        }
    }
}
