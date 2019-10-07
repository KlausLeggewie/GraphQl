namespace Domain.EmployeeDomain
{
    public class Employee
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string Gender { get; set; }

        public static Employee Create(int id, bool isActiveValue, int ageValue, string firstNameValue, string lastNameValue, string genderValue)
        {
            var employee = new Employee
            {
                Id = id,
                IsActive = isActiveValue,
                Age = ageValue,
                FirstName = firstNameValue,
                LastName = lastNameValue,
                Gender = genderValue
            };
            return employee;
        }

        /// <summary>
        /// Set active or inactive. Actually, not really needed. But may become useful, if more things happen when employee is getting active or inactive.
        /// </summary>
        /// <param name="active"></param>
        public void SetActive(bool active)
        {
            IsActive = active;
        }


    }
}