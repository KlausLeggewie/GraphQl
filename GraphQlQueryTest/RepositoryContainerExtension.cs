using Repositories;
using Unity;
using Unity.Extension;


namespace DependencyInjection
{
    /// <summary>
    /// Registration of Implementations for Unity container
    /// </summary>
    public class RepositoryContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
