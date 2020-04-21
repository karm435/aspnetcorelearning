using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Employees.Data
{
    public static class DbInitializer
    {
        public static void Initiatlize(EmployeeContext employeeContext)
        {
            try
            {
                employeeContext.Database.EnsureCreated();
                if (employeeContext.Persons.Any())
                {
                    return; //Already seeded
                }

                var persons = new[]
                {
                    new Person {Age = 28, FirstName = "John", LastName = "Singh"},
                    new Person {Age = 25, FirstName = "Smith", LastName = "Sandhu"}
                };

                foreach (var p in persons)
                {
                    employeeContext.Persons.Add(p);
                }

                employeeContext.SaveChanges();

                var department = new Department()
                {
                    Name = "HR"
                };

                employeeContext.Departments.Add(department);
                employeeContext.SaveChanges();

                var manager = new Manager()
                {
                    PersonId = 2,
                    DepartmentId = 1
                };
                manager.SubOrdinates.Add(new Employee()
                {
                    PersonId = 1,
                    DepartmentId = 1
                });
                employeeContext.Managers.Add(manager);
                
                
                employeeContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}