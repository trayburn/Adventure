using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Adventure.Commands;
using Adventure.Data;
using Castle.Facilities.TypedFactory;
using System.Data.Entity;
using Adventure.Formatters;

namespace Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IWindsorContainer container = new WindsorContainer())
            {
                container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel));
                container.AddFacility<TypedFactoryFacility>();

                container.Register(
                    AllTypes.FromThisAssembly().BasedOn<ICommand>().WithServiceAllInterfaces(),
                    AllTypes.FromThisAssembly().BasedOn<IFormatter>().WithServiceAllInterfaces(),
                    Component.For<GameEngine>(), 
                    Component.For<IGameObjectQueries>().ImplementedBy<GameObjectQueries>(),
                    Component.For<IRepository>().ImplementedBy<Repository>().LifeStyle.Transient,
                    Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifeStyle.Transient,
                    Component.For<IRepositoryFactory>().AsFactory().LifeStyle.Transient,
                    Component.For<IRepositoryFactoryFactory>().AsFactory(),
                    Component.For<IConsoleWrapper>().ImplementedBy<ConsoleWrapper>(),
                    Component.For<DbContext>().ImplementedBy<AdventureDbContext>().LifeStyle.Transient
                    );

                var game = container.Resolve<GameEngine>();
                game.RunLoop();
            }
        }
    }
}