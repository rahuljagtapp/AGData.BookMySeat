using AGData.BookMySeat.Domain.Enums;

namespace AGData.BookMySeat.Application.DTOs
{
    public class UpdateEmployeeCommandDTO
    {

        public Guid EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public Role? EmployeeRole { get; set; }
    }
}
