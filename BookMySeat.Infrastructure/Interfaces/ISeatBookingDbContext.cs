using AGData.BookMySeat.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AGData.BookMySeat.Infrastructure.Interfaces

{
    public interface ISeatBookingDbContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<Visitor> Visitors { get; set; }
        DbSet<Seat> Seats { get; set; }
        DbSet<BookingRecord> BookingRecords { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
