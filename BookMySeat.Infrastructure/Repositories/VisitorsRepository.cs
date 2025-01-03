using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Application.Interfaces;
using AGData.BookMySeat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AGData.BookMySeat.Application.Services
{
    public class VisitorRepository : IVisitorRepository
    {
        private readonly SeatBookingDbcontext _dbContext;

        public VisitorRepository(SeatBookingDbcontext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Guid> AddVisitorAsync(Visitor visitor)
        {
            if (visitor == null)
                throw new ArgumentNullException(nameof(visitor), "Visitor cannot be null.");

            await _dbContext.Visitors.AddAsync(visitor);
            await _dbContext.SaveChangesAsync();
            return visitor.VisitorId;
        }

        public async Task<Guid> UpdateVisitorAsync(Guid visitorId, string? updatedVisitorName = null, string? updatedHostEmployee = null, Guid? updatedHostEmployeeId = null)
        {
            if (visitorId == Guid.Empty)
                throw new ArgumentException("Visitor ID cannot be empty.", nameof(visitorId));

            var existingVisitor = await _dbContext.Visitors.FindAsync(visitorId);
            if (existingVisitor == null)
                throw new InvalidOperationException("Visitor not found.");

            if (!string.IsNullOrEmpty(updatedVisitorName))
                existingVisitor.VisitorName = updatedVisitorName;

            if (!string.IsNullOrEmpty(updatedHostEmployee))
                existingVisitor.HostEmployee = updatedHostEmployee;

            if (updatedHostEmployeeId.HasValue)
                existingVisitor.HostEmployeeId = updatedHostEmployeeId.Value;

            await _dbContext.SaveChangesAsync();
            return existingVisitor.VisitorId;
        }

        public async Task<Guid> DeleteVisitorAsync(Guid visitorId)
        {
            if (visitorId == Guid.Empty)
                throw new ArgumentException("Visitor ID cannot be empty.", nameof(visitorId));

            var existingVisitor = await _dbContext.Visitors.FindAsync(visitorId);
            if (existingVisitor == null)
                throw new InvalidOperationException("Visitor not found.");

            _dbContext.Visitors.Remove(existingVisitor);
            await _dbContext.SaveChangesAsync();
            return existingVisitor.VisitorId;
        }

        public async Task<IEnumerable<Visitor>> GetAllVisitorsAsync(Employee currentUser)
        {
            return await _dbContext.Visitors.Where(v => v.HostEmployeeId == currentUser.EmployeeId).ToListAsync();
        }

        public async Task<Visitor> GetVisitorByIdAsync(Guid visitorId)
        {
            if (visitorId == Guid.Empty)
                throw new ArgumentException("Visitor ID cannot be empty.", nameof(visitorId));

            var visitor = await _dbContext.Visitors.FindAsync(visitorId);
            if (visitor == null)
                throw new KeyNotFoundException("Visitor not found.");

            return visitor;
        }
    }
}
