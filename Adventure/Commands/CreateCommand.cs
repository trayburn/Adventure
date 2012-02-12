using System;
using System.Linq;
using Adventure.Data;
using System.Collections.Generic;
using Adventure;
using Adventure.Formatters;

namespace Adventure.Commands
{
    public class CreateCommand : BaseDataCommand
    {
        public CreateCommand(IConsoleWrapper console, IRepositoryFactoryFactory factory, IGameObjectQueries queries, IFormatter[] formatters)
            : base(console, factory, queries, formatters)
        {
            AddCommandName("@create");
            AddCommandName("@c");
        }

        protected override bool ExecuteWithData(string cmd, IRepository repo, Player player)
        {
            var name = cmd.Split(new[] { ' ' }, 2)[1];
            repo.Add(new GameObject { Name = name, Location = player });
            console.WriteLine("You create a {0}.", name);
            return true;
        }
    }
}
