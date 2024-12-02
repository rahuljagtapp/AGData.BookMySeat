using AGData.BookMySeat.Application.DTOs;
using AGData.BookMySeat.Application.Interfaces;

public class UpdateEmployeeCommandHandler
{
    private readonly IEmployeeService _employeeService;

    public UpdateEmployeeCommandHandler(IEmployeeService employeeService)
    {
        _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
    }

    public async Task<Guid> Handle(UpdateEmployeeCommandDTO dto)
    {
      
        // Call the service class to execute business logic
        var result = await _employeeService.UpdateEmployeeAsync(
            dto.EmployeeId,
            dto.EmployeeName,
            dto.EmployeeRole
            
        );

        return result;
    }
}
