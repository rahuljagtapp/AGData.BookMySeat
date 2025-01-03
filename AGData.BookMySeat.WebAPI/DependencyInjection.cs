using AGData.BookMySeat.Application;
using AGData.BookMySeat.Infrastructure;

namespace MyApp.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureDI();
            services.AddApplicationDI();


            return services;
        }
    }
}