using System;
using System.Linq;
using Adventure.Data;
using Adventure;
using Adventure.Formatters;

namespace Adventure.Commands
{
    public class TakeCommand : BaseDataCommand
    {
        public TakeCommand(IConsoleWrapper console, IRepositoryFactoryFactory factory, IGameObjectQueries queries, IFormatter[] formatters)
            : base(console, factory, queries, formatters)
        {
            AddCommandName("take");
            AddCommandName("pickup");
            AddCommandName("get");
        }

        protected override bool ExecuteWithData(string cmd, IRepository repo, Player player)
        {
            var name = cmd.Split(' ')[1];
            var go = queries.FindInLocation(repo, player.Location, name);
            if (go != null)
            {
                go.Location = player;
                console.WriteLine("You pickup {0}.", name);
                return true;
            }
            else
            {
                console.WriteLine(STR_NoSuchObject, name);
                return false;
            }
        }

    }
}
