namespace FootballFieldManagmentAngularJS.DI
{
    using Autofac;
    using FootballFieldManagment.Core.Repositories;
    using FootballFieldManagment.Core.Services;
    using FootballFieldManagment.Repository;
    using FootballFieldManagment.Repository.Repositories;
    using FootballFieldManagment.Repository.UnitOfWork;
    using FootballFieldManagment.Service.MapProfile;
    using FootballFieldManagment.Service.Services;
    using System.Reflection;
    using Module = Autofac.Module;
    public class RepoServiceModule : Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IGenericService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<UnitOfWork>().InstancePerLifetimeScope(); 

            var activeDirectory = Assembly.GetExecutingAssembly(); 

           var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));

            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

           builder.RegisterAssemblyTypes(activeDirectory,repoAssembly, serviceAssembly).Where(x=>x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope(); 
           builder.RegisterAssemblyTypes(serviceAssembly, repoAssembly, serviceAssembly).Where(x=>x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope(); 
        }

    }
}
