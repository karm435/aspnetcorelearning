using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.Data
{
    public class Department : EntityBase
    {
        public string Name { get; set; }

        public List<Employee> Employees { get; } = new List<Employee>();
    }
}