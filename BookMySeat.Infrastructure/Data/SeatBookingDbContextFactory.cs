using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AGData.BookMySeat.Infrastructure.Data
{
    public class SeatBookingDbContextFactory : IDesignTimeDbContextFactory<SeatBookingDbcontext>
    {
        public SeatBookingDbcontext CreateDbContext(string[] args)
        {
            
            var optionsBuilder = new DbContextOptionsBuilder<SeatBookingDbcontext>();
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-01Q4TEG7\SQLEXPRESS;Database=master;Trusted_Connection=True;MultipleActiveResultSets=true;");
            return new SeatBookingDbcontext(optionsBuilder.Options);
        }
    }
}
