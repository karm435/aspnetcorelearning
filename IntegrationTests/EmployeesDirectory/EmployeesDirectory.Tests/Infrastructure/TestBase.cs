using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Employees.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace EmployeesDirectory.Tests.Infrastructure
{
    public class TestBase
    {
         readonly WebApplicationFactory<Startup> _webAppFactory = new WebApplicationFactory<Startup>();

        protected HttpClient Client { get; private set; }

        [OneTimeSetUp]
        protected virtual Task OneTimeSetup()
        {
            Client = _webAppFactory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(ConfigureServices);
                    builder.ConfigureTestServices(ConfigureTestServices);
                })
                .CreateClient();

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return Task.CompletedTask;
        }

        protected virtual void ConfigureServices(IServiceCollection services)
        {
        }

        protected virtual void ConfigureTestServices(IServiceCollection services)
        {
        }

        /// <summary>
        /// Default is localdb
        /// </summary>
        /// <returns></returns>
        protected virtual EmployeeContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<EmployeeContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BailReporting;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;

            return new EmployeeContext(options);            
        }
    }
}