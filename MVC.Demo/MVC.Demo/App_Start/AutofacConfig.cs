using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using MVC.Demo.Models;
using MVC.Demo.Repositories;

namespace MVC.Demo
{
    public class AutofacConfig
    {
        public static void Register()
        {
            // Let's build our dependency chain first
            var builder = new ContainerBuilder();

            // Register the DbContext and our (only) repository
            builder.RegisterType<PoiDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerRequest();

            builder.RegisterModelBinderProvider();
            builder.RegisterModelBinders();

            // Register the MVC controllers in this assembly
            builder.RegisterControllers(Assembly.GetCallingAssembly());

            // Now, use the builder to create the IOC-container.
            var container = builder.Build();

            // Register Autofac as the default resolver in MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        } 
    }
}