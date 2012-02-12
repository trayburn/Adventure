using System;
using Adventure.Data;
using Adventure;
using Adventure.Formatters;

namespace Adventure.Commands
{
    public class DropCommand : BaseDataCommand
    {
        public DropCommand(IConsoleWrapper console, IRepositoryFactoryFactory factory, IGameObjectQueries queries, IFormatter[] formatters)
            : base(console, factory, queries, formatters)
        {
            AddCommandName("drop");
            AddCommandName("putdown");
            AddCommandName("release");
        }

        protected override bool ExecuteWithData(string cmd, IRepository repo, Player player)
        {
            var name = cmd.Split(' ')[1];
            var go = queries.FindInLocation(repo, player, name);
            if (go != null)
            {
                go.Location = player.Location;
                console.WriteLine("You drop {0}.", name);
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
