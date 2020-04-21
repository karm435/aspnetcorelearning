using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.Data
{
    public class Manager : EntityBase
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        
        
        public List<Employee> SubOrdinates { get; } = new List<Employee>();
        
    }
}