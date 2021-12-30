using GraphQlTypes.Queries;
using GraphQL.Types;
using GraphQlTypes.Mutations;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQlTypes.Schemas
{

    /// <summary>
    /// GrapQL schema, clusters all types for "employee"
    /// </summary>
    public class EmployeeSchema : Schema
    {
        public EmployeeSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<EmployeeQuery>();
            Mutation = provider.GetRequiredService<EmployeeMutation>();
            //Subscription = 
        }
    }
}
