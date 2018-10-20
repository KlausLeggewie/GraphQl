using System.Collections.Generic;
using Domain.EmployeeDomain;

namespace Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeRepository()
        {
            Initializer();
        }

        private void Initializer()
        {
            Employees = new List<Employee>
            {
                new Employee
                {
                    Id = 0,
                    IsActive = true,
                    Age = 52,
                    FirstName = "Sanders",
                    LastName = "Craft",
                    Gender = "male"
                },
                new Employee
                {
                    Id = 1,
                    IsActive = true,
                    Age = 47,
                    FirstName = "Connie",
                    LastName = "Olson",
                    Gender = "female"
                },
                new Employee
                {
                    Id = 2,
                    IsActive = true,
                    Age = 41,
                    FirstName = "Weber",
                    LastName = "Atkinson",
                    Gender = "male"
                },
                new Employee
                {
                    Id = 3,
                    IsActive = true,
                    Age = 53,
                    FirstName = "Santana",
                    LastName = "Eaton",
                    Gender = "male"
                },
                new Employee
                {
                    Id = 4,
                    IsActive = true,
                    Age = 21,
                    FirstName = "Paul",
                    LastName = "Phillips",
                    Gender = "male"
                },
                new Employee
                {
                    Id = 5,
                    IsActive = false,
                    Age = 27,
                    FirstName = "Wilcox",
                    LastName = "Mcpherson",
                    Gender = "male"
                },
                new Employee
                {
                    Id = 6,
                    IsActive = true,
                    Age = 24,
                    FirstName = "Eliza",
                    LastName = "Santiago",
                    Gender = "female"
                },
                new Employee
                {
                    Id = 7,
                    IsActive = false,
                    Age = 54,
                    FirstName = "Green",
                    LastName = "Douglas",
                    Gender = "male"
                },
                new Employee
                {
                    Id = 8,
                    IsActive = true,
                    Age = 54,
                    FirstName = "Julia",
                    LastName = "Cardenas",
                    Gender = "female"
                },
                new Employee
                {
                    Id = 9,
                    IsActive = true,
                    Age = 43,
                    FirstName = "Frances",
                    LastName = "Stevenson",
                    Gender = "female"
                },
                new Employee
                {
                    Id = 10,
                    IsActive = false,
                    Age = 53,
                    FirstName = "Nolan",
                    LastName = "Sloan",
                    Gender = "male"
                },
                new Employee
                {
                    Id = 11,
                    IsActive = false,
                    Age = 55,
                    FirstName = "Nguyen",
                    LastName = "Buckley",
                    Gender = "male"
                },
                new Employee
                {
                    Id = 12,
                    IsActive = true,
                    Age = 31,
                    FirstName = "Cleveland",
                    LastName = "Pittman",
                    Gender = "male"
                },
                new Employee
                {
                    Id = 13,
                    IsActive = true,
                    Age = 28,
                    FirstName = "Kline",
                    LastName = "Todd",
                    Gender = "male"
                },
                new Employee
                {
                    Id = 14,
                    IsActive = true,
                    Age = 22,
                    FirstName = "Pierce",
                    LastName = "Goodman",
                    Gender = "male"
                }

            };
        }

        public List<Employee> Employees { get; set; }
    }
}