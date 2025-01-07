using AGData.BookMySeat.Application.Interfaces;
using AGData.BookMySeat.Application.Services;
using AGData.BookMySeat.Domain.Interfaces;
using AGData.BookMySeat.Infrastructure.Data;
using AGData.BookMySeat.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AGData.BookMySeat.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<SeatBookingDbContext>(options =>
            {
               
                options.UseSqlServer("Server=LAPTOP-01Q4TEG7\\SQLEXPRESS;Database=AgDataBMSDb;Trusted_Connection=True;TrustServerCertificate=True");

            });
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IBookingRepository, BookingRecordRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<IVisitorRepository, VisitorRepository>();

            //var connectionString = configuration.GetConnectionString("AGDataBMSConnectionString");

            //services.AddDbContext<SeatBookingDbcontext>(options =>
            //{
            //    options.UseSqlServer(connectionString);
            //});

            return services;
        }
    }
}
