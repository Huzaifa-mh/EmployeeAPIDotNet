using EmployeeAPICURD.Data;
using EmployeeAPICURD.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPICURD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailsController(EmployeeDbContext context) : ControllerBase
    {
        private readonly EmployeeDbContext _context = context;

        [HttpGet]
        public async Task<List<Employee>> GetEmployeeDetails()
        {
            return (await _context.Employees.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeDetailById(int id)
        {
            var LocateEmployee = await _context.Employees.FindAsync(id);

            if (LocateEmployee is null)
                return NotFound();
            
            return Ok(LocateEmployee);
        }

        [HttpPost]
        
        public async Task<ActionResult<Employee>> AddEmployee(Employee newEmployee)
        {
            if (newEmployee is null)
                return BadRequest();

            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeDetailById), new { id = newEmployee.EmployeeCode }, newEmployee);
        }

        [HttpPut("{code}")]
        public async Task<ActionResult<Employee>> UpdateEmployeeById (int code, Employee updatedEmployee)
        {
            //to check if the user give the data
            if (updatedEmployee is null)
                return BadRequest("Employee data is required");

            //to match the code with the url and the body
            if (code != updatedEmployee.EmployeeCode)
                return BadRequest("Employee Code mismatch between the url and body");

            var existingEmployee = await _context.Employees.FindAsync(code);
            if (existingEmployee is null)
                return NotFound($"Employee with the code {code} not found.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            existingEmployee.EmployeeName = updatedEmployee.EmployeeName;
            existingEmployee.EmployeeDepartment = updatedEmployee.EmployeeDepartment;
            existingEmployee.EmployeeAge = updatedEmployee.EmployeeAge;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{code}")]
        public async Task<ActionResult> DeleteEmployee(int code)
        {
            var locateEmployee = await _context.Employees.FindAsync(code);
            if (locateEmployee is null)
                return BadRequest($"Employee with the code {code} not found");

            _context.Employees.Remove(locateEmployee);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
