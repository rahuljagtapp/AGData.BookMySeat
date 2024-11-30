using Microsoft.EntityFrameworkCore;

using AGData.BookMySeat.Infrastructure.Data;
using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Domain.Interfaces;

namespace AGData.BookMySeat.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SeatBookingDbcontext dbContext;

        public EmployeeRepository(SeatBookingDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
        }

        public async Task<Employee> AddEmployeeAsync(Employee entity)
        {
            entity.EmployeeId = Guid.NewGuid();
            dbContext.Employees.Add(entity);

            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Employee> UpdateEmployeeAsync(Guid employeeId, Employee entity)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);

            if (employee is not null)
            {
                employee.Name = entity.EmployeeName;
              

                await dbContext.SaveChangesAsync();

                return employee;
            }

            return entity;
        }

        public async Task<bool> DeleteEmployeeAsync(Guid employeeId)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);

            if (employee is not null)
            {
                dbContext.Employees.Remove(employee);

                return await dbContext.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}
