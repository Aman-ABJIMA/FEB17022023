﻿using Domain;
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

        public Task<bool> AddEmployeeAsync(Employee employee)
        {
           return _employeeService.AddEmployeeAsync(employee);
        }

        public Task<bool> DeleteEmployeeAsync(int id)
        {
            return _employeeService.DeleteEmployeeAsync(id);
        }

        public Task<List<Employee>> GetAllEmployeeAsync()
        {
            return _employeeService.GetAllEmployeeAsync();
        }

        public Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return _employeeService.GetEmployeeByIdAsync(id);   
        }

        public Task<bool> UpdateEmployeeAsync(int id, Employee employee)
        {
            return _employeeService.UpdateEmployeeAsync(id, employee);
        }
    }
}
