using AGData.BookMySeat.Application.Interfaces;
using AGData.BookMySeat.Domain.Entities;

public class GetAllEmployeesQueryHandler
{
    private readonly IEmployeeService _employeeService;

    public GetAllEmployeesQueryHandler(IEmployeeService employeeService)
    {
        _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
    }

    public async Task<IEnumerable<Employee>> Handle()
    {
        // Call the service class to get all employees
        var employees = await _employeeService.GetAllEmployeesAsync();
        return employees;
    }
}
