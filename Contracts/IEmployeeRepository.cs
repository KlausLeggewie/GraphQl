using System.Collections.Generic;
using Domain.EmployeeDomain;

namespace Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> Employees { get; set; }
    }
}