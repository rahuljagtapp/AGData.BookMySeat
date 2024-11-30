using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Domain.Interfaces;
using MediatR;

namespace AGData.BookMySeat.Application.Queries
{
    public record GetAllEmployeesQuery() : IRequest<IEnumerable<Employee>>;
    public class GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
    {
        public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetEmployees();
        }
    }
}
