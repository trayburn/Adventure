using System;
using System.Linq;
using Adventure.Data;
using System.Collections.Generic;
using Adventure.Formatters;

namespace Adventure.Commands
{
    public class CreateRoomCommand : BaseDataCommand
    {
        public CreateRoomCommand(IConsoleWrapper console, IRepositoryFactoryFactory factory, IGameObjectQueries queries, IFormatter[] formatters)
            : base(console, factory, queries, formatters)
        {
            AddCommandName("@createroom");
            AddCommandName("@cr");
        }

        protected override bool ExecuteWithData(string cmd, IRepository repo, Player player)
        {
            var name = cmd.Split(new[] { ' ' }, 2)[1];
            var room = new Room()
            {
                Name = name
            };
            repo.Add(room);
            return true;
        }
    }
}
