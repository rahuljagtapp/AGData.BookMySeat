using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Application.Interfaces;

namespace AGData.BookMySeat.Application.Services
{
    public class VisitorRepository : IVisitorRepository
    {
        private readonly IVisitorRepository _visitorRepository;

        public VisitorRepository(IVisitorRepository visitorRepository)
        {
            _visitorRepository = visitorRepository ?? throw new ArgumentNullException(nameof(visitorRepository));
        }

        public async Task<Guid> AddVisitorAsync(Visitor visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException("Visitor cannot be null.");
            }

            if (string.IsNullOrEmpty(visitor.VisitorName))
            {
                throw new ArgumentNullException("Visitor name cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(visitor.HostEmployee))
            {
                throw new ArgumentNullException("Host employee cannot be null or empty.");
            }

            if (visitor.HostEmployeeId == Guid.Empty)
            {
                throw new ArgumentException("Host employee ID cannot be empty.", nameof(visitor.HostEmployeeId));
            }

            return await _visitorRepository.AddVisitorAsync(visitor);
        }

        public async Task<Guid> UpdateVisitorAsync(Guid visitorId, string? updatedVisitorName = null, string? updatedHostEmployee = null, Guid? updatedHostEmployeeId = null)
        {
            if (visitorId == Guid.Empty)
            {
                throw new ArgumentException("Visitor ID cannot be empty.", nameof(visitorId));
            }

            var existingVisitor = await _visitorRepository.GetVisitorByIdAsync(visitorId);
            if (existingVisitor == null)
            {
                throw new InvalidOperationException("Visitor not found.");
            }

            if (!string.IsNullOrEmpty(updatedVisitorName))
            {
                existingVisitor.VisitorName = updatedVisitorName;
            }

            if (!string.IsNullOrEmpty(updatedHostEmployee))
            {
                existingVisitor.HostEmployee = updatedHostEmployee;
            }

            if (updatedHostEmployeeId.HasValue)
            {
                existingVisitor.HostEmployeeId = updatedHostEmployeeId.Value;
            }

            return await _visitorRepository.UpdateVisitorAsync(visitorId, updatedVisitorName, updatedHostEmployee, updatedHostEmployeeId);
        }

        public async Task<Guid> DeleteVisitorAsync(Guid visitorId)
        {
            if (visitorId == Guid.Empty)
            {
                throw new ArgumentException("Visitor ID cannot be empty.", nameof(visitorId));
            }

            var existingVisitor = await _visitorRepository.GetVisitorByIdAsync(visitorId);
            if (existingVisitor == null)
            {
                throw new InvalidOperationException("Visitor not found.");
            }

            return await _visitorRepository.DeleteVisitorAsync(visitorId);
        }

        public async Task<IEnumerable<Visitor>> GetAllVisitorsAsync(Employee currentUser)
        {
            return await _visitorRepository.GetAllVisitorsAsync(currentUser);
        }

        public async Task<Visitor> GetVisitorByIdAsync(Guid visitorId)
        {
            if (visitorId == Guid.Empty)
            {
                throw new ArgumentException("Visitor ID cannot be empty.", nameof(visitorId));
            }

            return await _visitorRepository.GetVisitorByIdAsync(visitorId);
        }
    }
}
