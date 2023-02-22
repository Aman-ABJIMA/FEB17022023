using DataInterfaces;
using FormatAPI.Infrastructure.Handlers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FormatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeHandler _employeeHandler;

        public EmployeeController(IEmployeeHandler employeeHandler)
        {
            _employeeHandler = employeeHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var records = await _employeeHandler.GetAllEmployeeAsync();
            return Ok(records);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var records = await _employeeHandler.GetEmployeeByIdAsync(id);
            return Ok(records);

        }


        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody]Employee employee)
        {
            var add = await _employeeHandler.AddEmployeeAsync(employee);
            return Ok(add);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var delete = await _employeeHandler.DeleteEmployeeAsync(id);
            return Ok(delete);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody]Employee employee)
        {
            var update = await _employeeHandler.UpdateEmployeeAsync(id,employee);
            return Ok(update);
        }
    }
}
