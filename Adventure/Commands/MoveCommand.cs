using System;
using System.Linq;
using Adventure.Data;
using Adventure.Formatters;

namespace Adventure.Commands
{
    public class MoveCommand : BaseDataCommand
    {
        public MoveCommand(IConsoleWrapper console, IRepositoryFactoryFactory factory, IGameObjectQueries queries, IFormatter[] formatters)
            : base(console, factory, queries, formatters)
        {
        }

        public override bool IsValid(string cmd)
        {
            using (var fac = factory.Create())
            {
                var repo = fac.Create();
                var player = queries.GetPlayer(repo);

                var exit = queries.FindNearPlayer<Exit>(repo, player, cmd);
                return exit != null;
            }
        }

        protected override bool ExecuteWithData(string cmd, IRepository repo, Player player)
        {
            var exit = queries.FindNearPlayer<Exit>(repo, player, cmd);
            player.Location = exit.Destination;
            formatters.OfType<LookFormatter>().First().Format(player.Location);
            return true;
        }
    }
}
