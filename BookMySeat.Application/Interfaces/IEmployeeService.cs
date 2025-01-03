using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Domain.Enums;

namespace AGData.BookMySeat.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<Guid> AddEmployeeAsync(Employee newEmployee);

        Task<Guid> UpdateEmployeeAsync(Guid employeeId, string? updatedEmployeeName = null, Role? updatedEmployeeRole = null);

        Task<Guid> DeleteEmployeeAsync(Guid employeeId);

        Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        Task<Employee> GetEmployeeByIdAsync(Guid employeeId);
    }
}
