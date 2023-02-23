using Domain;
using Models;

namespace FormatAPI.Infrastructure.Handlers.Interfaces
{
    public interface IEmployeeHandler
    {
        Task<List<Employee>> GetAllEmployeeAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<bool> AddEmployeeAsync(EmployeeDetails employee);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<bool> UpdateEmployeeAsync(int id,EmployeeDetails employee);
        Task<bool> DeleteAllEmployeeAsync();

    }
}
