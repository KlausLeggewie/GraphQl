    using GraphQlTypes.Queries;
    using GraphQL.Types;
    using GraphQlTypes.Mutations;
    using Repositories;

    namespace GraphQlTypes.Schemas
    {

        /// <summary>
        /// GrapQL schema, clusters all types for "employee"
        /// </summary>
        public class EmployeeSchema : Schema
        {
            public EmployeeSchema(IEmployeeRepository employeeRepository)
            {
                Query = new EmployeeQuery(employeeRepository);
                Mutation =  new EmployeeMutation(employeeRepository);
                //Subscription = 
            }
        }
    }
