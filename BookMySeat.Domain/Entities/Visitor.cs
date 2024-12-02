namespace AGData.BookMySeat.Domain.Entities
{
    public class Visitor
    {
        public Guid VisitorId { get; set; }
        public string VisitorName { get; set; }

        public string HostEmployee {  get;  set; }
        public Guid HostEmployeeId { get; set; }

        public Visitor() { }
    }
}
