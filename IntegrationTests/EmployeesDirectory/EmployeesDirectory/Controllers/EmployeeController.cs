using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Employees.Data;
using EmployeesDirectory.Extensions;
using EmployeesDirectory.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesDirectory.Controllers
{
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        [HttpPost]
        public IActionResult Post([FromBody]EmployeeModel employeeModel)
        {
            try
            {
                var employee = employeeModel.ToEmployee();

                _employeeContext.Employees.Add(employee);

                _employeeContext.SaveChanges();

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
        
        [HttpGet]
        public IEnumerable<EmployeeModel> Get()
        {
            var employees = _employeeContext.Employees.Select(employee => new EmployeeModel()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Age = employee.Age,
            });

            return employees.ToArray();
        }
    }
}