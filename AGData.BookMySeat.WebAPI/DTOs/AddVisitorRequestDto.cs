namespace AGData.BookMySeat.WebAPI.DTOs
{
    public class AddVisitorRequestDto
    {
        public string VisitorName { get; set; } = string.Empty;
        public string HostEmployee { get; set; } = string.Empty;

        public Guid HostEmployeeId { get; set; }
    }
}
