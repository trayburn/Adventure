using System;
using System.Linq;
using Adventure.Data;
using System.Collections.Generic;
using Adventure.Formatters;

namespace Adventure.Commands
{
    public class CreateExitCommand : BaseDataCommand
    {
        public CreateExitCommand(IConsoleWrapper console, IRepositoryFactoryFactory factory, IGameObjectQueries queries, IFormatter[] formatters)
            : base(console, factory, queries, formatters)
        {
            AddCommandName("@createexit");
            AddCommandName("@ce");
        }

        protected override bool ExecuteWithData(string cmd, IRepository repo, Player player)
        {
            var parameters = cmd.Split(new[] { ' ' }, 2)[1];
            var name = parameters.Split('=')[0];
            var destination = parameters.Split('=')[1];

            Room destRoom = queries.Find<Room>(repo, destination);
            if (destRoom == null)
            {
                console.WriteLine("Can't find that room");
                return false;
            }

            var exit = new Exit()
            {
                Destination = destRoom,
                Location = player.Location,
                Name = name
            };
            repo.Add(exit);

            return true;
        }
    }
}
