using JWTImplementation.Interfaces;
using JWTImplementation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController( IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Employee> Get()
        {
            var employees = _employeeService.GetEmployeeDetails();
            return employees;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            var emp = _employeeService.GetEmployeeDetails(id);
            return emp;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public Employee Post([FromBody] Employee employee)
        {
           var emp = _employeeService.AddEmployee(employee);
            return emp;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public Employee Put(int id, [FromBody] Employee value)
        {
            var emp = _employeeService.UpdateEmployee(value);
            return emp;
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var isDeleted = _employeeService.DeleteEmployee(id);
            return isDeleted;
        }
    }
}
