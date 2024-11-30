using AGData.BookMySeat.Application.Events;
using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Domain.Interfaces;
using MediatR;

namespace AGData.BookMySeat.Application.Commands
{
    public record AddEmployeeCommand(Employee Employee) : IRequest<Employee>;


    public class AddEmployeeCommandHandler(IEmployeeRepository employeeRepository, IPublisher mediator)
        : IRequestHandler<AddEmployeeCommand, Employee>
    {
        public async Task<Employee> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var user = await employeeRepository.AddEmployeeAsync(request.Employee);
            await mediator.Publish(new UserCreatedEvent(user.EmployeeId));
            return user;
        }
    }
}
