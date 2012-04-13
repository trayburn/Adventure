using System;
using System.Linq;
using Adventure.Data;
using System.Collections.Generic;
using Adventure.Formatters;

namespace Adventure.Commands
{
    public class AliasCommand : BaseDataCommand
    {
        public AliasCommand(IConsoleWrapper console, IRepositoryFactoryFactory factory, IGameObjectQueries queries, IFormatter[] formatters)
            : base(console, factory, queries, formatters)
        {
            AddCommandName("@alias");
            AddCommandName("@a");
        }

        protected override bool ExecuteWithData(string cmd, IRepository repo, Player player)
        {
            var parameters = cmd.Split(new[] { ' ' }, 2)[1];
            bool addAlias = parameters.Contains("+=");

            string splitVal;
            if (addAlias) splitVal = "+=";
            else splitVal = "-=";

            var goName = parameters.Split(new[] { splitVal }, StringSplitOptions.None)[0];
            var aliasName = parameters.Split(new[] { splitVal }, StringSplitOptions.None)[1];

            var go = queries.FindNearPlayer(repo, player, goName);
            if (go == null)
            {
                formatters.OfType<NotFoundFormatter>().First().Format(go);
                return false;
            }
            else
            {
                var alias = repo.AsQueryable<Tag>().FirstOrDefault(m => m.Value == aliasName);

                if (addAlias)
                {
                    if (alias == null)
                    {
                        alias = new Tag { Value = aliasName };
                        repo.Add(alias);
                        console.WriteLine("Alias created.");
                    }
                    go.Aliases.Add(alias);
                    console.WriteLine("Alias added.");
                }
                else
                {
                    if (alias == null)
                    {
                        console.WriteLine("That alias does not exist");
                    }
                    else
                    {
                        go.Aliases.Remove(alias);
                        console.WriteLine("Alias removed.");
                    }
                }
                return true;
            }
        }
    }
}
