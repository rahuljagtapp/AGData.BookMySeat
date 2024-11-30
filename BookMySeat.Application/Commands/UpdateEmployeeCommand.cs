using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Domain.Enums;
using AGData.BookMySeat.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGData.BookMySeat.Application.Commands
{

    public record UpdateEmployeeCommand(Guid EmployeeId, string EmployeeName, Role EmployeeRole) : IRequest<bool>;
    public class UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await employeeRepository.GetEmployeeByIdAsync(request.EmployeeId);

            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {request.EmployeeId} not found.");
            }

            
            employee.EmployeeName = request.EmployeeName;
            employee.EmployeeRole = request.EmployeeRole;

            await employeeRepository.UpdateEmployeeAsync(request.EmployeeId, employee);
            return true; 
        }
    }

}
