using AGData.BookMySeat.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AGData.BookMySeat.Infrastructure.Data
{
    public class SeatBookingDbcontext(DbContextOptions<SeatBookingDbcontext> options):DbContext(options)
    {
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<BookingRecord> BookingRecords { get; set; }
    }
}
