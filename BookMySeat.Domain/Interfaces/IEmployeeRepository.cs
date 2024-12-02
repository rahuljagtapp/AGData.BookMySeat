using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Domain.Enums;
using System;
using System.Collections.Generic;

namespace AGData.BookMySeat.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeByIdAsync(Guid id);
        Task<Guid> AddEmployeeAsync(Employee entity);
        Task<Guid> UpdateEmployeeAsync(Guid employeeId, string? employeeName = null, Role? employeeRole=null );
        Task<Guid> DeleteEmployeeAsync(Guid employeeId);
    }
}
