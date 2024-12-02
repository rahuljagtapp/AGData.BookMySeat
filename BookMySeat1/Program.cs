using AGData.BookMySeat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookMySeat1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //step 1: Build the configuration to read the connection string from appsetting.json 
            var configuration = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())  // This points to the root directory of your project
       .AddJsonFile("C:\\Users\\Rahul Jagtap\\source\\repos\\BookMySeat1\\appsetting.json", optional: false, reloadOnChange: true)  // Path to the appsettings.json file in the root directory
       .Build();


            Console.WriteLine("Hello, World1!");  // Prints the text and moves to the next line.



            // step 2:Set up Dependency Injection for the application
            var serviceProvider = new ServiceCollection()
            .AddDbContext<SeatBookingDbcontext>(options =>
                options.UseSqlServer("Data Source=LAPTOP-01Q4TEG7\\SQLEXPRESS;Initial Catalog=AGDataBookMySeat;TrustServerCertificate=True;Integrated Security=True")
            )
            .BuildServiceProvider();
            Console.WriteLine("Hello, World!2");  // Prints the text and moves to the next line.



            // Create scope and get DbContext instance
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<SeatBookingDbcontext>();

                // Example: Use the DbContext (e.g., perform a query or operation)
                var employees = dbContext.Employees.ToList();
                foreach (var employee in employees)
                {
                    Console.WriteLine($"Employee ID: {employee.EmployeeId}, Name: {employee.EmployeeName}");
                }
            }
            Console.WriteLine("Hello, World!3");  // Prints the text and moves to the next line.




        }
    }
}
