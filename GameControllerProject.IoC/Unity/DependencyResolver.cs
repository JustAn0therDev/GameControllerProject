using System.Data.Entity;
using Unity;
using Unity.Lifetime;
using prmToolkit.NotificationPattern;
using GameControllerProject.Domain.Interfaces.Repositories;
using GameControllerProject.Domain.Interfaces.Repositories.Base;
using GameControllerProject.Domain.Interfaces.Services;
using GameControllerProject.Domain.Services;
using GameControllerProject.Infra.Persistence;
using GameControllerProject.Infra.Persistence.Repositories;
using GameControllerProject.Infra.Persistence.Repositories.Base;
using GameControllerProject.Infra.Transactions;

namespace GameControllerProject.IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {

            container.RegisterType<DbContext, GameControllerProjectContext>(new HierarchicalLifetimeManager());
            //UnitOfWork
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            //Serviço de Domain
            //container.RegisterType(typeof(IServiceBase<,>), typeof(ServiceBase<,>));

            container.RegisterType<IPlayerService, PlayerService>(new HierarchicalLifetimeManager());

            //Repository
            container.RegisterType(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

            container.RegisterType<IPlayerRepository, PlayerRepository>(new HierarchicalLifetimeManager());
        }
    }
}