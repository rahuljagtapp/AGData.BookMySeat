using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Domain.Enums;
using System;
using System.Collections.Generic;

namespace AGData.BookMySeat.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        //Guid AddEmployee(Employee newEmployee);

        //string UpdateEmployee(Guid employeeId, string? updatedEmployeeName = null, Role? updatedEmployeeRole = null);

        //string DeleteEmployee(Guid employeeId);

        //IEnumerable<Employee> GetAllEmployees();

        //Employee? GetEmployeeById(Guid employeeId);

        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeByIdAsync(Guid id);
        Task<Employee> AddEmployeeAsync(Employee entity);
        Task<Employee> UpdateEmployeeAsync(Guid employeeId, Employee entity);
        Task<bool> DeleteEmployeeAsync(Guid employeeId);
    }
}
