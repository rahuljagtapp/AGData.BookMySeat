using AGData.BookMySeat.Domain.Enums;

namespace AGData.BookMySeat.Domain.Entities
{

    public class Employee
    {
        
        public Guid EmployeeId { get;  private set; }
        public string EmployeeName { get; private set; }
        public Role EmployeeRole { get; private set; }
        

        public Employee()
        {
        }
        public Employee(string employeeName, Role employeeRole)
        {
            EmployeeName = employeeName;
            EmployeeRole = employeeRole;
        }
        public void UpdateEmployeeName(string newName)
        {
            if (!string.IsNullOrWhiteSpace(newName))
            {
                EmployeeName = newName;
            }
        }

        
        public void UpdateEmployeeRole(Role newRole)
        {
            EmployeeRole = newRole;
        }

    }

}
