namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string commandPostFix = "Command";

        public string Read(string args)
        {
            string[] commandParts = args.Split(" ");
            string commandName = commandParts[0];
            string commandTypeName = commandName + commandPostFix;

            Type commandType = Assembly.GetCallingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.Name == nameof(ICommand)))
                .FirstOrDefault(t => t.Name == commandTypeName);

            if (commandType == null)
            {
                throw new InvalidOperationException("Command type is invalid!");
            }

            ICommand command = (ICommand)Activator.CreateInstance(commandType);

            string[] commandData = commandParts.Skip(1).ToArray();
            string result = command.Execute(commandData);

            return result;
        }
    }
}
