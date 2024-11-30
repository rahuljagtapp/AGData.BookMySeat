using AGData.BookMySeat.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AGData.BookMySeat.Domain.Interfaces
{
    public interface IVisitorRepository
    {

        Task<IEnumerable<Visitor>> GetAllVisitorsAsync(Employee currentUser);
        Task<Visitor> GetVisitorByIdAsync(Guid visitorId);
        Task<Visitor> AddVisitorAsync(Visitor visitor);
        Task<Visitor> UpdateVisitorAsync(Guid visitorId, Visitor visitor);
        Task<bool> DeleteVisitorAsync(Guid visitorId);

        //Guid AddVisitor(Visitor newVisitor, Employee currentUser);
        //string UpdateVisitor(Employee currentUser, Guid visitorId, string? updatedVisitorName = null, string? updatedHostEmployee = null);
        //string DeleteVisitor(Guid visitorId, Employee currentUser);
        //Visitor GetVisitorById(Guid visitorId, Employee currentUser);
        //IEnumerable<Visitor> GetAllVisitors(Employee currentUser);
    }
}
