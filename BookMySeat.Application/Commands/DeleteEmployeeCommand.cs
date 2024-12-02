using AGData.BookMySeat.Application.DTOs;
using AGData.BookMySeat.Application.Interfaces;
using AGData.BookMySeat.Domain.Entities;

public class DeleteEmployeeCommandHandler
{
    private readonly IEmployeeService _employeeService;

    public DeleteEmployeeCommandHandler(IEmployeeService employeeService)
    {
        _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
    }

    public async Task<Guid> Handle(DeleteEmployeeCommandDTO dto)
    {
      

         // Call the service class to execute business logic
        var result = await _employeeService.DeleteEmployeeAsync(dto.EmployeeId);
        return result;
    }
}
