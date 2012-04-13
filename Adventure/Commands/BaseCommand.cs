using System;
using System.Linq;
using Adventure.Data;
using System.Collections.Generic;
using Adventure.Formatters;

namespace Adventure.Commands
{
    public abstract class BaseCommand : ICommand
    {
        protected const string STR_NoSuchObject = "You don't see a {0}.";
        protected readonly IConsoleWrapper console;
        protected readonly IFormatter[] formatters;
        private readonly List<string> commandNames;

        public BaseCommand(IConsoleWrapper console, IFormatter[] formatters)
        {
            this.console = console;
            this.formatters = formatters;
            this.commandNames = new List<string>();
        }

        protected void AddCommandName(string cmdName)
        {
            commandNames.Add(cmdName.ToLower());
        }

        public virtual bool IsValid(string cmd)
        {
            var cmdName = cmd.Split(' ')[0].ToLower();
            return commandNames.Any(m => m == cmdName);
        }

        public abstract void Execute(string cmd);
    }
}
