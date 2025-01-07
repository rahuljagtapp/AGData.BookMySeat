using AGData.BookMySeat.Application.Interfaces;
using AGData.BookMySeat.Application.Services;
using MyApp.Api;

namespace AGData.BookMySeat.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.Configure<ConnectionStringOptions>(builder.Configuration.GetSection(ConnectionStringOptions.SectionName));

            builder.Services.AddAppDI(builder.Configuration);
           // builder.Services.AddAutoMapper(typeof(EmployeeProfile));



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
            });

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

       

        
    }
}
