using Unity;
using prmToolkit.NotificationPattern;
using System.Data.Entity;
using GameControllerProject.Domain.Interfaces.Repositories;
using GameControllerProject.Domain.Interfaces.Repositories.Base;
using GameControllerProject.Domain.Interfaces.Services;
using GameControllerProject.Domain.Services;
using GameControllerProject.Infra.Persistence;
using GameControllerProject.Infra.Persistence.Repositories;
using GameControllerProject.Infra.Persistence.Repositories.Base;
using GameControllerProject.Infra.Transactions;
using Microsoft.Practices.Unity;

namespace GameControllerProject.IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(Microsoft.Practices.Unity.UnityContainer container)
        {

            container.RegisterType<DbContext, GameControllerProjectContext>(new HierarchicalLifetimeManager());
            //UnitOfWork
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            //Serviço de Domain
            //container.RegisterType(typeof(IServiceBase<,>), typeof(ServiceBase<,>));

            container.RegisterType<IPlayerService, PlayerService>(new HierarchicalLifetimeManager());
            container.RegisterType<IGameService, GameService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPlatformService, PlatformService>(new HierarchicalLifetimeManager());

            //Repository
            container.RegisterType(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

            container.RegisterType<IPlayerRepository, PlayerRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IGameRepository, GameRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPlatformRepository, PlatformRepository>(new HierarchicalLifetimeManager());



        }
    }
}