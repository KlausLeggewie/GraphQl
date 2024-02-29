using GraphQlTypes.Queries;
using GraphQL.Types;
using GraphQlTypes.Mutations;
using System;

namespace GraphQlTypes.Schemas
{

    /// <summary>
    /// GrapQL schema, clusters all types for "employee"
    /// </summary>
    public class EmployeeSchema : Schema
    {
        public EmployeeSchema(IServiceProvider provider, EmployeeQuery query, EmployeeMutation mutation) : base(provider)
        {
            Query = query;
            Mutation = mutation;
            //Subscription = 
        }
    }
}