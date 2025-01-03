namespace AGData.BookMySeat.Domain.Entities
{
    public class Visitor
    {
        public Guid VisitorId { get; private set; }
        public string VisitorName { get; private set; }
        public string HostEmployee { get; private set; }
        public Guid HostEmployeeId { get; private set; }

        private Visitor() { }

        public Visitor(string visitorName, string hostEmployee, Guid hostEmployeeId)
        {
            VisitorId = Guid.NewGuid();
            VisitorName = visitorName;
            HostEmployee = hostEmployee;
            HostEmployeeId = hostEmployeeId;
        }

        public void UpdateVisitorName(string newName)
        {
            if (!string.IsNullOrWhiteSpace(newName))
            {
                VisitorName = newName;
            }
        }

        public void UpdateHostEmployee(string newHostEmployee, Guid newHostEmployeeId)
        {
            if (!string.IsNullOrWhiteSpace(newHostEmployee))
            {
                HostEmployee = newHostEmployee;
                HostEmployeeId = newHostEmployeeId;
            }
        }
    }
}
