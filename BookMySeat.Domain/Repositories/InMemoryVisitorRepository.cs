//using AGData.BookMySeat.Domain.Entities;
//using AGData.BookMySeat.Domain.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace AGData.BookMySeat.Domain.Repositories
//{
//    public class IVisitorRepository : IVisitorRepository
//    {
//        private readonly List<Visitor> _visitorsList = new List<Visitor>();

//        public Guid AddVisitor(Visitor newVisitor, Employee currentUser)
//        {
//            _visitorsList.Add(newVisitor);
//            return newVisitor.VisitorId;
//        }

//        public string UpdateVisitor(Employee currentUser, Guid visitorId, string? updatedVisitorName = null, string? updatedHostEmployee = null)
//        {
//            var existingVisitor = _visitorsList.FirstOrDefault(v => v.VisitorId == visitorId);
//            if (existingVisitor == null)
//            {
//                throw new InvalidOperationException("Visitor not found.");
//            }

//            if (!string.IsNullOrEmpty(updatedVisitorName))
//                existingVisitor.VisitorName = updatedVisitorName;

//            if (!string.IsNullOrEmpty(updatedHostEmployee))
//                existingVisitor.HostEmployee = updatedHostEmployee;

//            return "Visitor updated successfully.";
//        }

//        public string DeleteVisitor(Guid visitorId, Employee currentUser)
//        {
//            var visitorToDelete = _visitorsList.FirstOrDefault(v => v.VisitorId == visitorId);
//            if (visitorToDelete == null)
//            {
//                throw new InvalidOperationException("Visitor not found.");
//            }

//            _visitorsList.Remove(visitorToDelete);
//            return "Visitor deleted successfully.";
//        }

//        public Visitor GetVisitorById(Guid visitorId, Employee currentUser)
//        {
//            var visitor = _visitorsList.FirstOrDefault(v => v.VisitorId == visitorId);

//            if (visitor == null)
//            {
//                throw new InvalidOperationException("Visitor not found.");
//            }

//            return visitor;
//        }


//        public IEnumerable<Visitor> GetAllVisitors(Employee currentUser)
//        {
//            return _visitorsList;
//        }
//    }
//}
