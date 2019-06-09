using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjection;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphQlTypes.Queries;
using Repositories;
using Unity;


namespace GraphQlQueryTest
{
    [TestClass]
    public class EmployeeQueryTest
    {

        private const string simpleQuery = @"query { 
        employee 
        { 
            id 
            firstName 
            lastName 
          } 
        }";

        private const string extQuery = @"query { 
        employee(id: 1)
        {
            id
            firstName
            lastName
            age
            isActive
            gender
        }
    }";


        [TestMethod]
        public void TestEmployeeQuery()
        {
            // todo: used mockup repo
            // todo: test di separately

            // configure di
            var container = new UnityContainer();
            container.AddExtension(new RepositoryContainerExtension());

            IEmployeeRepository employeeRepository = container.Resolve<IEmployeeRepository>();

            var task = ExecuteEmployeeQuery(employeeRepository);
            var result = task.GetAwaiter().GetResult();

            Assert.IsNotNull(result.Data as System.Collections.Generic.IDictionary<string, object>);

            var dict = (System.Collections.Generic.IDictionary<string, object>) result.Data;

            string firstKey = dict.Keys.FirstOrDefault();
            Debug.WriteLine(firstKey);
            Assert.IsTrue(firstKey == "employee");

            Assert.IsNotNull(dict[firstKey]);


            var resultasjson =
                new DocumentWriter(indent: true).Write(result);
            Assert.IsNotNull(resultasjson);

            Debug.WriteLine(resultasjson);
        }

        private static async Task<ExecutionResult> ExecuteEmployeeQuery(IEmployeeRepository employeeRepository)
        {
            var result = await new DocumentExecuter().ExecuteAsync(options =>
            {
                options.Schema = new Schema
                {
                    Query = new EmployeeQuery(employeeRepository)
                };
                options.Query = extQuery;
            }).ConfigureAwait(false);
            return result;
        }

    }
}
