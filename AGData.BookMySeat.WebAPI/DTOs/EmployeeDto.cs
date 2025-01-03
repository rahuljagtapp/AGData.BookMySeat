using AGData.BookMySeat.Domain.Enums;

namespace AGData.BookMySeat.WebAPI.DTOs
{
    public class EmployeeDto
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public Role EmployeeRole { get; set; }
    }
}
