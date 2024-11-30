using AGData.BookMySeat.Domain.Enums;

namespace AGData.BookMySeat.Domain.Entities
{

    public class Employee
    {
        
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public Role EmployeeRole { get; set; }
        

        public Employee()
        {
        }

    }

}
