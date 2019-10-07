using System;
using System.Linq;
using Domain.EmployeeDomain;
using GraphQL.Types;
using GraphQlTypes.GraphTypes;
using Repositories;

namespace GraphQlTypes.Mutations
{
    public class EmployeeMutation : ObjectGraphType<Employee>
    {
        /// <summary>
        /// repo for query
        /// </summary>
        private readonly IEmployeeRepository _employeeRepository;


        /// <summary>
        /// defines resolving of mutations and arguments for repo
        /// </summary>
        /// <param name="employeeRepository"></param>
        public EmployeeMutation(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

            Field<EmployeeGraphType>("createEmployee",
                arguments: new QueryArguments(

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
                    new QueryArgument<BooleanGraphType>
                    {
                        Name = "isActive",
                        DefaultValue = null
                    },
                    new QueryArgument<IntGraphType>
                    {
                        Name = "age",
                        DefaultValue = 0
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "gender",
                        DefaultValue = ""
                    }
                ),
                resolve: OnCreateEmployee);

            Field<EmployeeGraphType>("setActive",
                arguments: new QueryArguments(

                    new QueryArgument<IntGraphType>
                    {
                        Name = "id",
                        DefaultValue = null

                    },
                    new QueryArgument<BooleanGraphType>
                    {
                        Name = "isActive",
                        DefaultValue = null
                    }
                ),
                resolve: OnSetActive);


        }

        private Employee OnCreateEmployee(ResolveFieldContext<Employee> resolveFieldContext)
        {
            if (_employeeRepository == null) return null;

            var isActiveValue = resolveFieldContext.
                GetArgument<bool>("isActive");
            var ageValue = resolveFieldContext.
                GetArgument<int>("age");
            var firstNameValue = resolveFieldContext.
                GetArgument<string>("firstName");
            var lastNameValue = resolveFieldContext.
                GetArgument<string>("lastName");
            var genderValue = resolveFieldContext.
                GetArgument<string>("gender");

            int newId = _employeeRepository.Employees.Max(e => e.Id) + 1;

            Employee employee = Employee.Create(newId, isActiveValue, ageValue, firstNameValue, lastNameValue, genderValue);

            _employeeRepository.Employees.Add(employee);

            return employee;
        }



        private Employee OnSetActive(ResolveFieldContext<Employee> resolveFieldContext)
        {
            if (_employeeRepository == null) return null;

            var idValue = resolveFieldContext.
                GetArgument<int?>("id");

            if (idValue == null)
            {
                throw new ArgumentException($"\"id\" argument is missing");
            }

            var isActiveValue = resolveFieldContext.
                GetArgument<bool?>("isActive");

            if (isActiveValue == null)
            {
                throw new ArgumentException($"\"isActive\" argument is missing");
            }

            var employee = _employeeRepository.Employees.FirstOrDefault(e => e.Id == idValue.Value);

            // push mutation to domain
            employee?.SetActive(isActiveValue.Value);

            return employee;
        }
    }

}
