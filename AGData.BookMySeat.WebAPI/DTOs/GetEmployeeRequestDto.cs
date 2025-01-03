namespace AGData.BookMySeat.WebAPI.DTOs
{
    public class GetEmployeeRequestDto
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string EmployeeRole { get; set; } = string.Empty;
    }
}
