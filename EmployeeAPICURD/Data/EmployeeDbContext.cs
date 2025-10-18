using EmployeeAPICURD.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPICURD.Data
{
    public class EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employees => Set<Employee>();
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeCode = 1001,
                    EmployeeName = "Huzaifa",
                    EmployeeDepartment = "Software",
                    EmployeeAge = 21
                },
                new Employee
                {
                    EmployeeCode = 1002,
                    EmployeeName = "Muhammad",
                    EmployeeDepartment = "HR",
                    EmployeeAge = 21
                }
                );
        }
    }
}