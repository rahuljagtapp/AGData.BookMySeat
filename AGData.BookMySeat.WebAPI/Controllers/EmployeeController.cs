using AGData.BookMySeat.Application.Interfaces;
using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Domain.Enums;
using AGData.BookMySeat.WebAPI.CustomActionFilter;
using AGData.BookMySeat.WebAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
    }

    [HttpGet("{id:Guid}")]
    [ValidateModel]
    public async Task<IActionResult> GetEmployeeByIDAsync([FromRoute] Guid id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);
        if (employee == null)
            return NotFound("Employee not found.");

        var employeeDto = new GetEmployeeRequestDto
        {
            EmployeeId = employee.EmployeeId,
            EmployeeName = employee.EmployeeName,
            EmployeeRole = employee.EmployeeRole.ToString()
        };

        return Ok(employeeDto);
    }

    [HttpPost]
    [ValidateModel]
    public async Task<IActionResult> AddEmployeeAsync([FromBody] AddEmployeeRequestDto newEmployeeDto)
    {
        if (!Enum.TryParse<Role>(newEmployeeDto.EmployeeRole, out var role))
        {
            return BadRequest("Invalid role provided.");
        }

        var newEmployee = new Employee(newEmployeeDto.EmployeeName, role);


        var addedEmployeeId = await _employeeService.AddEmployeeAsync(newEmployee);
        return CreatedAtAction("GetEmployeeByID", new { id = newEmployee.EmployeeId }, newEmployee.EmployeeId);
    }

    [HttpPut("{id:Guid}")]
    [ValidateModel]
    public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] Guid id, [FromBody] UpdateEmployeeRequestDto updatedEmployeeDto)
    {
        var updatedEmployeeId = await _employeeService.UpdateEmployeeAsync(
            id,
            updatedEmployeeDto.EmployeeName,
            Enum.TryParse<Role>(updatedEmployeeDto.EmployeeRole, out var role) ? role : null);

        var updatedEmployee = await _employeeService.GetEmployeeByIdAsync(updatedEmployeeId);
        var updatedEmployeeDtoResult = new GetEmployeeRequestDto
        {
            EmployeeId = updatedEmployee.EmployeeId,
            EmployeeName = updatedEmployee.EmployeeName,
            EmployeeRole = updatedEmployee.EmployeeRole.ToString()
        };

        return Ok(updatedEmployeeDtoResult);
    }


   
    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] Guid id)
    {
        await _employeeService.DeleteEmployeeAsync(id);
        return NoContent();
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllEmployeeAsync()
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        var employeeDtos = employees.Select(x => new EmployeeDto
        {
            EmployeeId = x.EmployeeId,
            EmployeeName = x.EmployeeName,
            EmployeeRole = x.EmployeeRole
        }).ToList();

        return Ok(employeeDtos);
    }
}
