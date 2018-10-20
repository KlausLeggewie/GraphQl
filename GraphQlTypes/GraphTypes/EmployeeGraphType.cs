using GraphQL.Types;
using Domain.EmployeeDomain;

namespace GraphQlTypes.GraphTypes
{
    /// <summary>
    /// This is our GraphQL-Type definition for the employee
    /// </summary>
    public class EmployeeGraphType : ObjectGraphType<Employee>
    {
        public EmployeeGraphType()
        {
            Name = "employee";
            Description = "a person";

            Field(x => x.Id);
            Field(x => x.IsActive);
            Field(x => x.Age);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.Gender);
        }
    }
}

