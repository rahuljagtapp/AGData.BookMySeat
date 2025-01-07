using AGData.BookMySeat.Domain.Entities;
namespace AGData.BookMySeat.Application.Interfaces
{
    public interface IVisitorService
    {
        Task<Guid> AddVisitorAsync(Visitor newVisitor, Employee currentUser);
        Task<Guid> UpdateVisitorAsync(Employee currentUser, Guid visitorId, string? updatedVisitorName = null, string? updatedHostEmployee = null, Guid? updatedHostEmployeeId = null);
        Task<Guid> DeleteVisitorAsync(Guid visitorId, Employee currentUser);
        Task<Visitor> GetVisitorByIdAsync(Guid visitorId, Employee currentUser);
        Task<IEnumerable<Visitor>> GetAllVisitorsAsync(Employee currentUser);
    }
}
