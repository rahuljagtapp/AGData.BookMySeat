using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Domain.Enums;
using System;
using System.Collections.Generic;

namespace AGData.BookMySeat.Application.Interfaces
{
    public interface IVisitorService
    {
        Guid AddVisitor(Visitor newVisitor, Employee currentUser);
        string UpdateVisitor(Employee currentUser, Guid visitorId, string? updatedVisitorName = null, string? updatedHostEmployee = null);
        string DeleteVisitor(Guid visitorId, Employee currentUser);
        Visitor GetVisitorById(Guid visitorId, Employee currentUser);
        IEnumerable<Visitor> GetAllVisitors(Employee currentUser);
    }
}
