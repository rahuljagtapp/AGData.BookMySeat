using AGData.BookMySeat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AGData.BookMySeat.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<SeatBookingDbcontext>(options =>
            {
                options.UseSqlServer(@"Server=LAPTOP-01Q4TEG7\SQLEXPRESS;Database=master;Trusted_Connection=True;MultipleActiveResultSets=true;");
            });

            return services;
        }
    }
}
