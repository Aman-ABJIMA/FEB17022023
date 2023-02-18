using DataInterfaces;
using FormatAPI.Infrastructure.Handlers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
       // private readonly IEmployeeRepository _employeeRepository;
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
    }
}
