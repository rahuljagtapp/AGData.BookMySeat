using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Domain.Enums;

namespace AGData.BookMySeat.Application.Interfaces
{
    public interface IEmployeeService
    { 

        Task<Guid> AddEmployeeAsync(Employee newEmployee, Employee currentUser);

        Task<bool> UpdateEmployeeAsync(Guid employeeId, string? updatedEmployeeName = null, Role? updatedEmployeeRole = null);

        Task<bool> DeleteEmployeeAsync(Guid employeeId);

        Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        Task<Employee> GetEmployeeByIdAsync(Guid employeeId);

        //Guid AddEmployee(Employee newEmployee, Employee currentUser);
        //string UpdateEmployee(Guid employeeId, string? updatedEmployeeName = null, Role? updatedEmployeeRole = null);
        //string DeleteEmployee(Guid employeeId);
        //IEnumerable<Employee> GetAllEmployees();
        //Employee GetEmployeeById(Guid employeeId);
    }
}
