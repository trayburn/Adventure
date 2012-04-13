using System;
using System.Linq;
using Adventure.Data;
using System.Collections.Generic;
using Adventure.Formatters;

namespace Adventure.Commands
{
    public class StatusCommand : BaseDataCommand
    {
        public StatusCommand(IConsoleWrapper console, IRepositoryFactoryFactory factory, IGameObjectQueries queries, IFormatter[] formatters)
            : base(console, factory, queries, formatters)
        {
            AddCommandName("@status");
            AddCommandName("@s");
        }

        protected override bool ExecuteWithData(string cmd, IRepository repo, Player player)
        {
            var parameters = cmd.Split(new[] { ' ' }, 2)[1];
            bool addStatus = parameters.Contains("+=");

            string splitVal;
            if (addStatus) splitVal = "+=";
            else splitVal = "-=";

            var goName = parameters.Split(new[] { splitVal }, StringSplitOptions.None)[0];
            var statusName = parameters.Split(new[] { splitVal }, StringSplitOptions.None)[1];

            var go = queries.FindNearPlayer(repo, player, goName);
            if (go == null)
            {
                formatters.OfType<NotFoundFormatter>().First().Format(go);
                return false;
            }
            else
            {
                var alias = repo.AsQueryable<Tag>().FirstOrDefault(m => m.Value == statusName);

                if (addStatus)
                {
                    if (alias == null)
                    {
                        alias = new Tag { Value = statusName };
                        repo.Add(alias);
                        console.WriteLine("Status created.");
                    }
                    go.Statuses.Add(alias);
                    console.WriteLine("Status added.");
                }
                else
                {
                    if (alias == null)
                    {
                        console.WriteLine("That status does not exist");
                    }
                    else
                    {
                        go.Statuses.Remove(alias);
                        console.WriteLine("Status removed.");
                    }
                }
                return true;
            }
        }
    }
}
