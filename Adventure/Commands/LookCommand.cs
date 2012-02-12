using System;
using System.Linq;
using Adventure.Data;
using Adventure;
using Adventure.Formatters;

namespace Adventure.Commands
{
    public class LookCommand : BaseDataCommand
    {
        public LookCommand(IConsoleWrapper console, IRepositoryFactoryFactory factory, IGameObjectQueries queries, IFormatter[] formatters)
            : base(console, factory, queries, formatters)
        {
            AddCommandName("look");
            AddCommandName("l");
        }

        protected override bool ExecuteWithData(string cmd, IRepository repo, Player player)
        {
            string[] cmdArray = cmd.Split(new[] { ' ' }, 2);

            string name = "";
            if (cmdArray.GetUpperBound(0) >= 1)
                name = cmdArray[1].Trim();

            GameObject target;

            switch (name.ToLower())
            {
                case "here":
                case "":
                    target = player.Location;
                    break;
                default:
                    target = queries.FindNearPlayer(repo, player, name);
                    break;
            }

            if (target == null)
            {
                console.WriteLine(STR_NoSuchObject, name);
                return false;
            }

            formatters.OfType<LookFormatter>().First().Format(target);
            formatters.OfType<InventoryFormatter>().First().Format(target);
            return false;
        }

    }
}
