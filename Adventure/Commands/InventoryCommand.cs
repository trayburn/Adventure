using System;
using System.Linq;
using Adventure.Data;
using Adventure;
using Adventure.Formatters;

namespace Adventure.Commands
{
    public class InventoryCommand : BaseDataCommand
    {
        public InventoryCommand(IConsoleWrapper console, IRepositoryFactoryFactory factory, IGameObjectQueries queries, IFormatter[] formatters)
            : base(console, factory, queries, formatters)
        {
            AddCommandName("inventory");
            AddCommandName("inv");
            AddCommandName("i");
        }

        protected override bool ExecuteWithData(string cmd, IRepository repo, Player player)
        {
            formatters.OfType<InventoryFormatter>().First().Format(player);
            return false;
        }

    }
}
