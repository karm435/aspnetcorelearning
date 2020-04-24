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
                if (employeeContext.Employees.Any())
                {
                    return; //Already seeded
                }

                var persons = new[]
                {
                    new Employee() {Age = 25, FirstName = "Smith", LastName = "Sandhu"}
                };

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