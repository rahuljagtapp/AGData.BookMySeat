using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Domain.Enums;
using AGData.BookMySeat.Application.Interfaces;

namespace AGData.BookMySeat.Application.Services
{
    public class VisitorService : IVisitorService
    {
        private readonly IVisitorRepository _visitorRepository;

        public VisitorService(IVisitorRepository visitorRepository)
        {
            _visitorRepository = visitorRepository ?? throw new ArgumentNullException(nameof(visitorRepository), "Visitor repository cannot be null.");
        }

        private void CheckAdminRole(Employee currentUser)
        {
            if (currentUser.EmployeeRole != Role.Admin)
            {
                throw new UnauthorizedAccessException("Only an Admin can perform this operation.");
            }
        }

        public async Task<Guid> AddVisitorAsync(Visitor newVisitor, Employee currentUser)
        {
            CheckAdminRole(currentUser);

            if (newVisitor == null)
                throw new ArgumentNullException(nameof(newVisitor), "Visitor cannot be null.");

            if (string.IsNullOrWhiteSpace(newVisitor.VisitorName))
                throw new ArgumentException("Visitor name cannot be empty or null.", nameof(newVisitor.VisitorName));

            if (string.IsNullOrWhiteSpace(newVisitor.HostEmployee))
                throw new ArgumentException("Host employee name cannot be empty or null.", nameof(newVisitor.HostEmployee));

            var existingVisitor = await _visitorRepository.GetVisitorByIdAsync(newVisitor.VisitorId);
            if (existingVisitor != null)
                throw new InvalidOperationException($"Visitor with ID {newVisitor.VisitorId} already exists.");

            return await _visitorRepository.AddVisitorAsync(newVisitor);
        }

        public async Task<Guid> UpdateVisitorAsync(Employee currentUser, Guid visitorId, string? updatedVisitorName = null, string? updatedHostEmployee = null)
        {
            CheckAdminRole(currentUser);

            if (visitorId == Guid.Empty)
                throw new ArgumentException("Visitor ID cannot be empty.", nameof(visitorId));

            var existingVisitor = await _visitorRepository.GetVisitorByIdAsync(visitorId);
            if (existingVisitor == null)
                throw new InvalidOperationException("Visitor not found.");

            if (!string.IsNullOrEmpty(updatedVisitorName))
                existingVisitor.VisitorName = updatedVisitorName;

            if (!string.IsNullOrEmpty(updatedHostEmployee))
                existingVisitor.HostEmployee = updatedHostEmployee;

            return await _visitorRepository.UpdateVisitorAsync(visitorId, updatedVisitorName, updatedHostEmployee);
        }

        public async Task<Guid> DeleteVisitorAsync(Guid visitorId, Employee currentUser)
        {
            CheckAdminRole(currentUser);

            if (visitorId == Guid.Empty)
                throw new ArgumentException("Visitor ID cannot be empty.", nameof(visitorId));

            var existingVisitor = await _visitorRepository.GetVisitorByIdAsync(visitorId);
            if (existingVisitor == null)
                throw new InvalidOperationException("Visitor not found.");

            return await _visitorRepository.DeleteVisitorAsync(visitorId);
        }

        public async Task<Visitor> GetVisitorByIdAsync(Guid visitorId, Employee currentUser)
        {
            CheckAdminRole(currentUser);

            if (visitorId == Guid.Empty)
                throw new ArgumentException("Visitor ID cannot be empty.", nameof(visitorId));

            var visitor = await _visitorRepository.GetVisitorByIdAsync(visitorId);
            if (visitor == null)
                throw new KeyNotFoundException($"Visitor with ID {visitorId} not found.");

            return visitor;
        }

        public async Task<IEnumerable<Visitor>> GetAllVisitorsAsync(Employee currentUser)
        {
            CheckAdminRole(currentUser);

            var visitors = await _visitorRepository.GetAllVisitorsAsync(currentUser);
            if (visitors == null || !visitors.Any())
                throw new InvalidOperationException("No visitors found.");

            return visitors;
        }
    }
}
