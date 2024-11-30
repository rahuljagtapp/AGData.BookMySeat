using AGData.BookMySeat.Infrastructure;
using AGData.BookMySeat.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace BookMySeat1
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Hello, World!");
            // Set up Dependency Injection for the application
            var serviceProvider = new ServiceCollection()
                .AddInfrastructureDI()  // Ensure this is called to add your DbContext configuration
                .BuildServiceProvider();

            // Create scope and get DbContext instance
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<SeatBookingDbcontext>();


        }
    }
}
