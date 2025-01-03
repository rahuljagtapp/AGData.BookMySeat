namespace AGData.BookMySeat.WebAPI.DTOs
{
    public class VisitorDto
    {
        public Guid VisitorId { get; set; }
        public string VisitorName { get; set; }

        public string HostEmployee { get; set; }
        public Guid HostEmployeeId { get; set; }
    }
}
