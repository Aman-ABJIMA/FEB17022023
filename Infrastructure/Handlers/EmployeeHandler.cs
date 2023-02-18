using FormatAPI.Infrastructure.Handlers.Interfaces;
using Models;
using ServiceInterfaces;

namespace FormatAPI.Infrastructure.Handlers
{
    public class EmployeeHandler : IEmployeeHandler
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public Task<List<Employee>> GetAllEmployeeAsync()
        {
            return _employeeService.GetAllEmployeeAsync();
        }
    }
}
