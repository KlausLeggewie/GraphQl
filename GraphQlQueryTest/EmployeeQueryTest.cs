using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Execution;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphQlTypes.Queries;
using Repositories;


namespace GraphQlQueryTest;

/// <summary>
/// Test class <code>EmployeeQuery</code>
/// </summary>
[TestClass]
public class EmployeeQueryTest
{

    private const string TestQuery = @"query { 
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
    public async Task TestEmployeeQuery()
    {
        // usually we would mockup the repo; in this case we use the sample repo
        IEmployeeRepository employeeRepository = new EmployeeRepository();

        var task = ExecuteEmployeeQuery(employeeRepository);
        var executionResult = task.GetAwaiter().GetResult();

        Assert.IsNotNull(executionResult.Data);
            
        var dict = (System.Collections.Generic.IDictionary<string, object>)((ExecutionNode)executionResult.Data).ToValue();

        string firstKey = dict?.Keys.FirstOrDefault();
        Debug.WriteLine(firstKey);
        Assert.IsTrue(firstKey == "employee");

        Assert.IsNotNull(dict[firstKey]);

        string jsonStringResult;
        await using (var ms = new MemoryStream())
        {
            var writer = new GraphQLSerializer(indent: true);
            await writer.WriteAsync(ms, executionResult);

            jsonStringResult = Encoding.UTF8.GetString(ms.ToArray());
        }

        Assert.IsNotNull(jsonStringResult);

        Debug.WriteLine(jsonStringResult);
    }

    private static async Task<ExecutionResult> ExecuteEmployeeQuery(IEmployeeRepository employeeRepository)
    {
        var result = await new DocumentExecuter().ExecuteAsync(options =>
        {
            options.Schema = new Schema
            {
                Query = new EmployeeQuery(employeeRepository)
            };
            options.Query = TestQuery;
        }).ConfigureAwait(false);
        return result;
    }

}