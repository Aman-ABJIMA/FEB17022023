using DataInterfaces;
using FormatAPI.Infrastructure.Handlers.Interfaces;
using FormatAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FormatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeHandler _employeeHandler;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeHandler employeeHandler,ILogger<EmployeeController> logger)
        {
            _employeeHandler = employeeHandler;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ResponseWrapper<List<Employee>>> GetAllEmployee()
        { 
            var response = new ResponseWrapper<List<Employee>>();
            try
            {
                response.Set( await _employeeHandler.GetAllEmployeeAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in FormatAPI/Controller/EmployeeController/{GetAllEmployee}",ex);
                response.Set(ex);
            }
            return response;
           
        }


        [HttpGet("{id}")]
        public async Task<ResponseWrapper<Employee>> GetEmployeeById(int id)
        {
            var response = new ResponseWrapper<Employee>();
            try
            {
                response.Set(await _employeeHandler.GetEmployeeByIdAsync(id));
            }
            catch(Exception ex)
            {
                _logger.LogError("Exception in FormatAPI/Controller/EmployeeController/{id}",ex);
                response.Set(ex);
            }
            return response;
        }


        [HttpPost]
        public async Task<ResponseWrapper<bool>> AddEmployee([FromBody]EmployeeDetails employee)
        {
            var response = new ResponseWrapper<bool>(); 
            try
            {
                response.Set(await _employeeHandler.AddEmployeeAsync(employee));
            }
            catch(Exception ex)
            {
                _logger.LogError("Exception in FormatAPI/Controller/EmployeeController/{AddEmployee}", ex);
                response.Set(ex);
            }
            return response;
         
        }

        [HttpDelete("{id}")]
        public async Task<ResponseWrapper<bool>> DeleteEmployee(int id)
        {
            var response=new ResponseWrapper<bool>();
            try
            {
                response.Set(await _employeeHandler.DeleteEmployeeAsync(id));
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in FormatAPI/Controller/EmployeeController/{DeleteEmployee}",ex);
                response.Set(ex);
            }
            return response;
        }

        [HttpPut("{id}")]
        public async Task<ResponseWrapper<bool>> UpdateEmployee(int id, [FromBody]EmployeeDetails employee)
        {
            var response = new ResponseWrapper<bool>();
            try
            {
                response.Set(await _employeeHandler.UpdateEmployeeAsync(id,employee));
            }
            catch(Exception ex)
            {
                _logger.LogError("Exception in FormatAPI/Controller/EmployeeController/{UpdateEmployee}",ex);
            }
            return response;
          
        }
        [HttpDelete]
        public async Task<ResponseWrapper<bool>> DeleteAllEmployee()
        {
            var response = new ResponseWrapper<bool>();
            try
            {
                response.Set(await _employeeHandler.DeleteAllEmployeeAsync());
            }
            catch(Exception ex)
            {
                _logger.LogError("Exception in FormatAPI/EmployeeController/{DeleteAll}",ex);
                response.Set(ex);
            }
            return response;
        }
    }
}
