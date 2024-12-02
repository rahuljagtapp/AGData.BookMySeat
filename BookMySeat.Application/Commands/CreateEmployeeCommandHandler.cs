using AGData.BookMySeat.Application.DTOs;
using AGData.BookMySeat.Application.Interfaces;
using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Domain.Enums;

public class CreateEmployeeCommandHandler
{
    private readonly IEmployeeService _employeeService;

    public CreateEmployeeCommandHandler(IEmployeeService employeeService)
    {
        _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
    }

    public async Task<Guid> Handle(CreateEmployeeDto dto)
    {
        if (!Enum.TryParse(dto.EmployeeRole, out Role employeeRole))
        {
            throw new ArgumentException("Invalid Employee Role.", nameof(dto.EmployeeRole));
        }

        var newEmployee = new Employee
        {
            EmployeeName = dto.EmployeeName,
            EmployeeRole =employeeRole
        };
        var currentUser = new Employee
        {
            EmployeeName = "Abhishek Goyal",
            EmployeeRole = 0
        };

        // Call the service class to execute business logic
        var result = await _employeeService.AddEmployeeAsync(newEmployee,currentUser);
        return result;
    }
}
