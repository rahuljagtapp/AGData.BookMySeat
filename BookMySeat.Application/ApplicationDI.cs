using Microsoft.Extensions.DependencyInjection;
using AGData.BookMySeat.Application.Interfaces;
using AGData.BookMySeat.Application.Services;
using AGData.BookMySeat.Domain.Interfaces;
using AGData.BookMySeat.Infrastructure.Repositories;

namespace AGData.BookMySeat.Application
{
    public static class ApplicationDI
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ISeatService, SeatService>();
            services.AddScoped<IVisitorService, VisitorService>();
            
            return services;
        }
    }
}
