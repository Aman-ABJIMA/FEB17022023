using Models;

namespace FormatAPI.Infrastructure.Handlers.Interfaces
{
    public interface IEmployeeHandler
    {
        Task<List<Employee>> GetAllEmployeeAsync();
    }
}
