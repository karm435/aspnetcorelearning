using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.Data
{
    public class Employee : EntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Age { get; set; }
        
    }
}