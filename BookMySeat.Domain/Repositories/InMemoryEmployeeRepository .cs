//using AGData.BookMySeat.Domain.Entities;
//using AGData.BookMySeat.Domain.Enums;
//using AGData.BookMySeat.Domain.Interfaces;

//namespace AGData.BookMySeat.Domain.Repositories
//{
//    public class InMemoryEmployeeRepository : IEmployeeRepository
//    {
//        private readonly List<Employee> _employeesList = new List<Employee>()
//        {
             
//        };

//        public Guid AddEmployee(Employee newEmployee)
//        {
//            Console.WriteLine("inside employee repo");
//            _employeesList.Add(newEmployee);
//            return newEmployee.EmployeeId;
//        }

//        public string UpdateEmployee(Guid employeeId, string? updatedEmployeeName = null, Role? updatedEmployeeRole = null)
//        {
//            var existingEmployee = _employeesList.FirstOrDefault(e => e.EmployeeId == employeeId);

//            if (existingEmployee == null)
//            {
//                return "Employee not found.";
//            }

//            if (!string.IsNullOrEmpty(updatedEmployeeName))
//            {
//                existingEmployee.EmployeeName = updatedEmployeeName;
//            }

//            if (updatedEmployeeRole.HasValue)
//            {
//                existingEmployee.EmployeeRole = updatedEmployeeRole.Value;
//            }

//            return "Employee information updated successfully.";
//        }
//        public string DeleteEmployee(Guid employeeId)
//        {
//            var employeeToDelete = _employeesList.FirstOrDefault(e => e.EmployeeId == employeeId);
//            if (employeeToDelete != null)
//            {
//                _employeesList.Remove(employeeToDelete);
//                return "Employee deleted successfully";
//            }
//            return "Employee not found.";
//        }

//        public IEnumerable<Employee> GetAllEmployees()
//        {
//            return _employeesList;
//        }

//        public Employee? GetEmployeeById(Guid employeeId)
//        {
//            if (employeeId == Guid.Empty)
//                throw new ArgumentNullException("employeeId is null");

//              return _employeesList.SingleOrDefault(e => e.EmployeeId == employeeId);
//        }
//    }
//}
