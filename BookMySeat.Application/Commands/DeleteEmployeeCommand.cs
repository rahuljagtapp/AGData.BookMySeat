using AGData.BookMySeat.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGData.BookMySeat.Application.Commands
{
    public record DeleteEmployeeCommand(Guid EmployeeId) : IRequest<bool>;
    public class DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
       : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await employeeRepository.GetEmployeeByIdAsync(request.EmployeeId);

            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {request.EmployeeId} not found.");
            }

            var success = await employeeRepository.DeleteEmployeeAsync(request.EmployeeId);

            return success;
        }
    }
}
