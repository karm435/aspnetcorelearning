using Microsoft.EntityFrameworkCore;

namespace Employees.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            :base(options)
        {
            
        }
        
        public DbSet<Person> Persons { get; set; }
        
        public DbSet<Employee> Employees { get; set; }
        
        public DbSet<Department> Departments { get; set; }

        public DbSet<Manager> Managers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Department>().ToTable("Departments");
            modelBuilder.Entity<Manager>().ToTable("Managers");
        }
    }
}