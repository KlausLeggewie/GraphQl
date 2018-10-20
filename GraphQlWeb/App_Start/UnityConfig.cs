using System.Web.Http;
using Unity;
using Unity.WebApi;
using DependencyInjection;

namespace GraphQlWeb
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.AddExtension(new RepositoryContainerExtension());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}