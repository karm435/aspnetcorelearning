using Employees.Data;
using EmployeesDirectory.Models;

namespace EmployeesDirectory.Extensions
{
    public static class EmployeeModelExtensions
    {
        public static Employee ToEmployee(this EmployeeModel model)
        {
            return new Employee()
            {
                Age = model.Age,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
        }
    }
}