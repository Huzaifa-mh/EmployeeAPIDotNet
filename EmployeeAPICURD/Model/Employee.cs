using System.ComponentModel.DataAnnotations;

namespace EmployeeAPICURD.Model
{
    public class Employee
    {
        [Key] //Primary key
        public int EmployeeCode { get; set; }
        [Required] //cant be null
        public string EmployeeName { get; set; }
        public string? EmployeeDepartment { get; set; }
        public int? EmployeeAge { get; set; }

    }
}
