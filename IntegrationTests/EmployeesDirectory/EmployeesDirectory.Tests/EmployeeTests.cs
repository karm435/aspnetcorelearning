using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Employees.Data;
using EmployeesDirectory.Models;
using EmployeesDirectory.Tests.Infrastructure;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace EmployeesDirectory.Tests
{
    public class EmployeeTests : InMemoryTests
    {
        private EmployeeContext _employeeContext;
        private string MediaType = "application/json";
        
        [SetUp]
        public void Setup()
        {
            _employeeContext = CreateDbContext();
            DbInitializer.Initiatlize(_employeeContext);
        }

        [Test]
        public async Task CreateEmployee()
        {
            var url = "/api/employees";

            var employeeModel = new EmployeeModel()
            {
                Age = 32,
                FirstName = "Harry",
                LastName = "Sodhi",
            };

            var content = JsonConvert.SerializeObject(employeeModel);

            var response = await Client.PostAsync(url, new StringContent(content, Encoding.UTF8, MediaType));
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            var allEmployeesResponseMessage = await Client.GetAsync(url);
            allEmployeesResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseContent = await allEmployeesResponseMessage.Content.ReadAsStringAsync();
            var employees =
                JsonConvert.DeserializeObject<IEnumerable<EmployeeModel>>(responseContent, new JsonSerializerSettings() {  });

            employees.Should().NotBeEmpty()
                .And
                .Contain(e => e.FirstName == "Harry" && e.LastName == "Sodhi");

        }
    }
}