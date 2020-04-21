using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.Data
{
    public class Person : EntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Age { get; set; }
        
    }
}