using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using GraphQL.Types;
using Domain.EmployeeDomain;
using GraphQL;
using GraphQlTypes.GraphTypes;
using Repositories;

namespace GraphQlTypes.Queries
{
    public class EmployeeQuery : ObjectGraphType<Employee>
    {

        /// <summary>
        /// repo for query
        /// </summary>
        private readonly IEmployeeRepository _employeeRepository;

        /// <summary>
        /// defines resolving of query and arguments on repo
        /// </summary>
        /// <param name="employeeRepository"></param>
        public EmployeeQuery(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
            Field<ListGraphType<EmployeeGraphType>>("employee",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>
                    {
                        Name = "id",
                        DefaultValue = 0
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "firstName",
                        DefaultValue = ""
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "lastName",
                        DefaultValue = ""
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "gender",
                        DefaultValue = ""
                    },
                    new QueryArgument<BooleanGraphType>
                    {
                        Name = "isActive",
                        DefaultValue = null
                    },
                    new QueryArgument<IntGraphType>
                    {
                        Name = "age",
                        DefaultValue = 0
                    }
                ),
                resolve: ResolveEmployees);
        }

        protected virtual IEnumerable<Employee> ResolveEmployees(IResolveFieldContext<Employee> resolveFieldContext)
        {
            var idValue =
                resolveFieldContext.GetArgument<int>("id");
            var isActiveValue = resolveFieldContext.
                GetArgument<bool?>("isActive");
            var ageValue = resolveFieldContext.
                GetArgument<int>("age");
            var firstNameValue = resolveFieldContext.
                GetArgument<string>("firstName");
            var lastNameValue = resolveFieldContext.
                GetArgument<string>("lastName");
            var genderValue = resolveFieldContext.
                GetArgument<string>("gender");

            StringBuilder query = new StringBuilder();

            if (idValue > 0)
            {
                query.AppendFormat($"Id == {idValue}");
            }
            if (ageValue > 0)
            {
                if (query.Length > 0)
                    query.Append(" AND ");
                query.AppendFormat($"Age == {ageValue}");
            }
            if (isActiveValue != null)
            {
                if (query.Length > 0)
                    query.Append(" AND ");
                query.AppendFormat($"IsActive == {isActiveValue}");
            }

            if (!string.IsNullOrWhiteSpace(firstNameValue))
            {
                if (query.Length > 0)
                    query.Append(" AND ");
                query.AppendFormat(
                    "FirstName.Contains({0}{1}{0})", (char)34,
                    firstNameValue);
            }
            if (!string.IsNullOrWhiteSpace(lastNameValue))
            {
                if (query.Length > 0)
                    query.Append(" AND ");
                query.AppendFormat(
                    "LastName.Contains({0}{1}{0})", (char)34,
                    lastNameValue);
            }
            if (!string.IsNullOrWhiteSpace(genderValue))
            {
                if (query.Length > 0)
                    query.Append(" AND ");
                query.AppendFormat(
                    "Gender =={0}{1}{0}", (char)34,
                    genderValue);
            }

            // further fields by same procedure...

            if (query.Length == 0)
                return _employeeRepository.Employees;

            return _employeeRepository.Employees.AsQueryable().Where(query.ToString());
        }
    }
}
