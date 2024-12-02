using AGData.BookMySeat.Application.Interfaces;
using AGData.BookMySeat.Domain.Entities;

public class GetEmployeeByIdQueryHandler
{
    private readonly IEmployeeService _employeeService;

    public GetEmployeeByIdQueryHandler(IEmployeeService employeeService)
    {
        _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
    }

    public async Task<Employee> Handle(Guid employeeId)
    {
        if (employeeId == Guid.Empty)
        {
            throw new ArgumentException("Employee ID cannot be empty.", nameof(employeeId));
        }

        // Call the service class to get the employee by ID
        var employee = await _employeeService.GetEmployeeByIdAsync(employeeId);

        if (employee == null)
        {
            throw new InvalidOperationException("Employee not found.");
        }

        return employee;
    }
}
