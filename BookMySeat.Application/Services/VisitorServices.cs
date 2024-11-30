using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Domain.Enums;
using AGData.BookMySeat.Application.Interfaces;
using AGData.BookMySeat.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Guid AddVisitor(Visitor newVisitor, Employee currentUser)
        {
            CheckAdminRole(currentUser);

            if (newVisitor == null)
                throw new ArgumentNullException(nameof(newVisitor), "Visitor cannot be null.");

            if (string.IsNullOrWhiteSpace(newVisitor.VisitorName))
                throw new ArgumentException("Visitor name cannot be empty or null.", nameof(newVisitor.VisitorName));

            if (string.IsNullOrWhiteSpace(newVisitor.HostEmployee))
                throw new ArgumentException("Host employee name cannot be empty or null.", nameof(newVisitor.HostEmployee));

            var existingVisitor = _visitorRepository.GetVisitorByIdAsync(newVisitor.VisitorId,currentUser);
            if (existingVisitor != null)
                throw new InvalidOperationException($"Visitor with ID {newVisitor.VisitorId} already exists.");

            return _visitorRepository.AddVisitor(newVisitor, currentUser);
        }

        public string UpdateVisitor(Employee currentUser,Guid visitorId, string? updatedVisitorName = null, string? updatedHostEmployee = null)
        {
            CheckAdminRole(currentUser);

            if (visitorId == Guid.Empty)
                throw new ArgumentException("Visitor ID cannot be empty.", nameof(visitorId));

            var existingVisitor = _visitorRepository.GetVisitorById(visitorId, currentUser);
            if (existingVisitor == null)
                throw new InvalidOperationException("Visitor not found.");

            if (!string.IsNullOrEmpty(updatedVisitorName))
                existingVisitor.VisitorName = updatedVisitorName;

            if (!string.IsNullOrEmpty(updatedHostEmployee))
                existingVisitor.HostEmployee = updatedHostEmployee;

            return _visitorRepository.UpdateVisitor(currentUser, visitorId, updatedVisitorName, updatedHostEmployee);
        }

        public string DeleteVisitor(Guid visitorId, Employee currentUser)
        {
            CheckAdminRole(currentUser);

            if (visitorId == Guid.Empty)
                throw new ArgumentException("Visitor ID cannot be empty.", nameof(visitorId));

            var existingVisitor = _visitorRepository.GetVisitorById(visitorId, currentUser);
            if (existingVisitor == null)
                throw new InvalidOperationException("Visitor not found.");

            return _visitorRepository.DeleteVisitor(visitorId, currentUser);
        }

        public Visitor GetVisitorById(Guid visitorId, Employee currentUser)
        {
            CheckAdminRole(currentUser);

            if (visitorId == Guid.Empty)
                throw new ArgumentException("Visitor ID cannot be empty.", nameof(visitorId));

            var visitor = _visitorRepository.GetVisitorById(visitorId, currentUser);
            if (visitor == null)
                throw new KeyNotFoundException($"Visitor with ID {visitorId} not found.");

            return visitor;
        }

        public IEnumerable<Visitor> GetAllVisitors(Employee currentUser)
        {
            CheckAdminRole(currentUser);

            var visitors = _visitorRepository.GetAllVisitorsAsync(currentUser);
            if (visitors == null || !visitors.Any())
                throw new InvalidOperationException("No visitors found.");

            return visitors;
        }
    }
}
