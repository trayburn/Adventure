using System;
using System.Linq;
using Adventure.Data;
using Adventure;
using Adventure.Formatters;

namespace Adventure.Commands
{
    public class SetCommand : BaseDataCommand
    {
        public SetCommand(IConsoleWrapper console, IRepositoryFactoryFactory factory, IGameObjectQueries queries, IFormatter[] formatters)
            : base(console, factory, queries, formatters)
        {
            AddCommandName("@set");
        }

        protected override bool ExecuteWithData(string cmd, IRepository repo, Player player)
        {
            SetParameters setParams = ParseCommand(cmd);
            GameObject go;
            if (setParams.GameObjectName == "here")
                go = player.Location;
            else 
                go = queries.FindNearPlayer(repo, player, setParams.GameObjectName);

            if (go == null)
            {
                console.WriteLine(STR_NoSuchObject, setParams.GameObjectName);
            }

            switch (setParams.Property.ToLower())
            {
                case "name":
                    go.Name = setParams.Value;
                    formatters.OfType<LookFormatter>().First().Format(go);
                    return true;
                case "desc":
                case "description":
                    go.Description = setParams.Value;
                    formatters.OfType<LookFormatter>().First().Format(go);
                    return true;
                default:
                    console.WriteLine("You cannot set {0} on {1}.", setParams.Property, setParams.GameObjectName);
                    return false;
            }
        }

        private SetParameters ParseCommand(string cmd)
        {
            var parameters = new SetParameters();

            string sansCommand = cmd.Split(new[] { ' ' }, 2)[1];
            string[] splitByEquals = sansCommand.Split(new[] { '=' }, 2);
            string[] splitByDot = splitByEquals[0].Split(new[] { '.' }, 2);

            parameters.Value = splitByEquals[1].Trim();
            parameters.Property = splitByDot[1].Trim();
            parameters.GameObjectName = splitByDot[0].Trim();
            return parameters;
        }

        public class SetParameters
        {
            public string GameObjectName { get; set; }
            public string Property { get; set; }
            public string Value { get; set; }
        }
    }
}
