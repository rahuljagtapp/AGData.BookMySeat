using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Domain.Interfaces;
using AGData.BookMySeat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AGData.BookMySeat.Infrastructure.Repositories
{
    public class VisitorRepository : IVisitorRepository
    {
        private readonly SeatBookingDbcontext _dbContext;

        public VisitorRepository(SeatBookingDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Visitor>> GetAllVisitorsAsync()
        {
            return await _dbContext.Visitors.ToListAsync();
        }

        public async Task<Visitor> GetVisitorByIdAsync(Guid visitorId)
        {

            var visitor = await _dbContext.Visitors
                .FirstOrDefaultAsync(v => v.VisitorId == visitorId);

            // Check if visitor is null
            if (visitor == null)
            {
                throw new KeyNotFoundException($"Visitor with ID {visitorId} not found.");
            }

            return visitor;
        }

        public async Task<Visitor> AddVisitorAsync(Visitor visitor)
        {
            visitor.VisitorId = Guid.NewGuid();
            _dbContext.Visitors.Add(visitor);
            await _dbContext.SaveChangesAsync();
            return visitor;
        }

        public async Task<Visitor> UpdateVisitorAsync(Guid visitorId, Visitor visitor)
        {
            var existingVisitor = await _dbContext.Visitors
                .FirstOrDefaultAsync(v => v.VisitorId == visitorId);

            if (existingVisitor != null)
            {
                existingVisitor.VisitorName = visitor.VisitorName;
                existingVisitor.HostEmployee = visitor.HostEmployee;
                existingVisitor.HostEmployeeId = visitor.HostEmployeeId;

                await _dbContext.SaveChangesAsync();

                return existingVisitor;
            }

            return null;
        }

        public async Task<bool> DeleteVisitorAsync(Guid visitorId)
        {
            var visitor = await _dbContext.Visitors
                .FirstOrDefaultAsync(v => v.VisitorId == visitorId);

            if (visitor != null)
            {
                _dbContext.Visitors.Remove(visitor);
                return await _dbContext.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}
