using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.Data
{
    public class Employee : EntityBase
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        
    }
}