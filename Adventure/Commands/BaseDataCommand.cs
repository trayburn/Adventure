using System;
using Adventure.Data;
using Adventure;
using Adventure.Formatters;

namespace Adventure.Commands
{
    public abstract class BaseDataCommand : BaseCommand
    {
        protected readonly IRepositoryFactoryFactory factory;
        protected readonly IGameObjectQueries queries;

        public BaseDataCommand(IConsoleWrapper console, IRepositoryFactoryFactory factory, IGameObjectQueries queries, IFormatter[] formatters)
            : base(console, formatters)
        {
            this.factory = factory;
            this.queries = queries;
        }

        public override void Execute(string cmd)
        {
            using (var fac = factory.Create())
            {
                var repo = fac.Create();
                var player = queries.GetPlayer(repo);

                // Do Something
                bool saveChanges = ExecuteWithData(cmd, repo, player);

                if (saveChanges)
                    repo.UnitOfWork.SaveChanges();
            }
        }
        protected abstract bool ExecuteWithData(string cmd, IRepository repo, Player player);
    }
}
