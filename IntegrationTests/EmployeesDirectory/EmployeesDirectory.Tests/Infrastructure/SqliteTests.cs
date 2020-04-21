using Employees.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace EmployeesDirectory.Tests.Infrastructure
{
    public class SqliteTests : TestBase
    {
        protected override EmployeeContext CreateDbContext()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open(); // need Microsoft.Data.Sqlite

            var options = new DbContextOptionsBuilder<EmployeeContext>()
                .UseSqlite(connection) //Need Microsoft.EntityFrameworkCore.Sqlite
                .Options;
            
            return new EmployeeContext(options);
        }
    }
}