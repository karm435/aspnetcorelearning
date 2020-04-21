using Employees.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeesDirectory.Tests.Infrastructure
{
    public class SqlDatabaseTests : TestBase
    {
        protected override EmployeeContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<EmployeeContext>()
                .UseSqlServer("Server=.\\SqlExpress;Database=BailReporting;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;

            return new EmployeeContext(options);    
        }
    }
}