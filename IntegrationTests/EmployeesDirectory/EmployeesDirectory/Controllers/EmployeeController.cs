using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Employees.Data;
using EmployeesDirectory.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesDirectory.Controllers
{
    public class EmployeeController
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        [HttpGet]
        public IEnumerable<EmployeeModel> GetAll()
        {
            var employees = _employeeContext.Employees.Select(employee => new EmployeeModel()
            {
                Id = employee.Id,
                FirstName = employee.Person.FirstName,
                LastName = employee.Person.LastName,
                Age = employee.Person.Age.ToString(CultureInfo.InvariantCulture),
            });

            return employees.ToArray();
        }

        [HttpGet]
        public EmployeeModel GetOne(int id)
        {
            var employee = _employeeContext.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return null;

            return
                new EmployeeModel()
                {
                    Id = employee.Id,
                    FirstName = employee.Person.FirstName,
                    LastName = employee.Person.LastName,
                    Age = employee.Person.Age.ToString(CultureInfo.InvariantCulture),
                };
        }

        public IEnumerable<EmployeeModel> GetMany(int managerId)
        {
            var employees = _employeeContext.Employees.Where(e => e.ManagerId == managerId);
            if (!employees.Any()) return null;
            
            return employees.Select(employee => new EmployeeModel()
            {
                Id = employee.Id,
                FirstName = employee.Person.FirstName,
                LastName = employee.Person.LastName,
                Age = employee.Person.Age.ToString(CultureInfo.InvariantCulture),
            }).ToArray();
        }
    }
}