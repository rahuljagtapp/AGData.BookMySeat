using AGData.BookMySeat.Infrastructure.Data;
using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using AGData.BookMySeat.Domain.Enums;

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
            if (id == Guid.Empty)
            {
                // You can either throw an exception or return null, depending on your needs
                throw new ArgumentException("Invalid GUID provided", nameof(id));
            }

            return await dbContext.Employees
                                  .FirstOrDefaultAsync(x => x.EmployeeId == id);
        }

        public async Task<Guid> AddEmployeeAsync(Employee entity)
        {
            // Create a new GUID for the employee if it's not provided
            entity.EmployeeId = Guid.NewGuid();
            dbContext.Employees.Add(entity);

            await dbContext.SaveChangesAsync();

            return entity.EmployeeId;  // Return the GUID of the newly added employee
        }

        public async Task<Guid> UpdateEmployeeAsync(Guid employeeId, string? employeeName = null, Role? employeeRole = null)
        {
            // Find the employee by their Id
            var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);

            if (employee is not null)
            {
                // Update properties only if they're not null
                if (employeeName != null)
                    employee.EmployeeName = employeeName;

                if (employeeRole.HasValue)
                    employee.EmployeeRole = employeeRole.Value;

                await dbContext.SaveChangesAsync();

                return employee.EmployeeId;  // Return the GUID of the updated employee
            }

            // If the employee doesn't exist, return the default Guid (possibly signaling failure)
            return Guid.Empty;
        }

        public async Task<Guid> DeleteEmployeeAsync(Guid employeeId)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);

            if (employee is not null)
            {
                dbContext.Employees.Remove(employee);
                await dbContext.SaveChangesAsync();

                return employee.EmployeeId;  // Return the GUID of the deleted employee
            }

            // If the employee doesn't exist, return the default Guid (possibly signaling failure)
            return Guid.Empty;
        }
    }
}
