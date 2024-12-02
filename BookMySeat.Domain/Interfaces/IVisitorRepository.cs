using AGData.BookMySeat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGData.BookMySeat.Application.Interfaces
{
    public interface IVisitorRepository
    {
        Task<Guid> AddVisitorAsync(Visitor visitor);
        Task<Guid> UpdateVisitorAsync(Guid visitorId, string? updatedVisitorName = null, string? updatedHostEmployee = null, Guid? updatedHostEmployeeId = null);
        Task<Guid> DeleteVisitorAsync(Guid visitorId);
        Task<IEnumerable<Visitor>> GetAllVisitorsAsync(Employee currentUser);
        Task<Visitor> GetVisitorByIdAsync(Guid visitorId);
    }
}
