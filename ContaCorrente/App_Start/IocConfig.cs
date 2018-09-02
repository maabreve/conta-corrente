using System.Web.Http;
using ContaCorrente.Repository;
using ContaCorrente.Repository.Interfaces;
using Ninject;

namespace ContaCorrente
{
    public class IocConfig
    {
        public static void RegisterIoc(HttpConfiguration config)
        {
            var kernel = new StandardKernel(); // Ninject IoC

            // These registrations are "per instance request".
            // See http://blog.bobcravens.com/2010/03/ninject-life-cycle-management-or-scoping/

            kernel.Bind<RepositoryFactories>().To<RepositoryFactories>()
                .InSingletonScope();
            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();
            kernel.Bind<IUnitOfWork>().To<ContaCorrenteUow>();

            // Tell WebApi how to use our Ninject IoC
            config.DependencyResolver = new NinjectMvcDependencyResolver(kernel); ;

        }
    }
}