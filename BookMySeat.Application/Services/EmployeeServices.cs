using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Domain.Enums;
using AGData.BookMySeat.Application.Interfaces;
using AGData.BookMySeat.Domain.Interfaces;

namespace AGData.BookMySeat.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<Guid> AddEmployeeAsync(Employee newEmployee)
        {
            if (!Enum.IsDefined(typeof(Role), newEmployee.EmployeeRole))
                throw new ArgumentException("Invalid employee role.", nameof(newEmployee.EmployeeRole));

           

            if (newEmployee == null)
                throw new ArgumentNullException(nameof(newEmployee), "Employee cannot be null.");

            if (string.IsNullOrEmpty(newEmployee.EmployeeName))
                throw new ArgumentException("Employee name cannot be empty.", nameof(newEmployee.EmployeeName));

            var addedEmployee = await _employeeRepository.AddEmployeeAsync(newEmployee);
            return addedEmployee;
        }

        public async Task<Guid> UpdateEmployeeAsync(Guid employeeId, string? updatedEmployeeName = null, Role? updatedEmployeeRole = null)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentException("Employee ID cannot be empty.", nameof(employeeId));

            var existingEmployee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);
            if (existingEmployee == null)
                throw new InvalidOperationException("Employee not found.");

            if (!string.IsNullOrEmpty(updatedEmployeeName))
            {
                existingEmployee.UpdateEmployeeName(updatedEmployeeName);
            }

            if (updatedEmployeeRole.HasValue)
            {
                existingEmployee.UpdateEmployeeRole(updatedEmployeeRole.Value);
            }

            var result = await _employeeRepository.UpdateEmployeeAsync(employeeId, existingEmployee.EmployeeName, existingEmployee.EmployeeRole);
            return result;
        }

        public async Task<Guid> DeleteEmployeeAsync(Guid employeeId)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentException("Employee ID cannot be empty.", nameof(employeeId));

            var existingEmployee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);
            if (existingEmployee == null)
                throw new InvalidOperationException("Employee not found.");

            var result = await _employeeRepository.DeleteEmployeeAsync(employeeId);
            return result;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetEmployees();
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid employeeId)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentException("Employee ID cannot be empty.", nameof(employeeId));

            return await _employeeRepository.GetEmployeeByIdAsync(employeeId);
        }
    }
}
