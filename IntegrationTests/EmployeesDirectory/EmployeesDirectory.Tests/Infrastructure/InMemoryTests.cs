using Employees.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeesDirectory.Tests.Infrastructure
{
    public class InMemoryTests: TestBase
    {
        protected override EmployeeContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<EmployeeContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDbForTesting")
                .Options;
            
            return new EmployeeContext(options);
        }
    }
}