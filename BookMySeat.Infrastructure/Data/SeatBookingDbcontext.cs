using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AGData.BookMySeat.Infrastructure.Data
{
    public class SeatBookingDbcontext:DbContext, ISeatBookingDbContext
    {
        public SeatBookingDbcontext(DbContextOptions<SeatBookingDbcontext> options): base(options) 
        {

        }

        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<BookingRecord> BookingRecords { get; set; }

         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(entity =>
            {
                
                entity.HasKey(e => e.EmployeeId);
                entity.Property(e => e.EmployeeName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.EmployeeRole).HasConversion<string>().IsRequired();
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                
                entity.Property(r => r.ResourceCategorey).IsRequired().HasMaxLength(50);
                entity.Property(r => r.ResourceName).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Visitor>(entity =>
            {
                
                entity.HasOne<Employee>().WithMany().HasForeignKey(v => v.HostEmployeeId).IsRequired();
                entity.Property(v => v.HostEmployee).HasMaxLength(100);
            });

            modelBuilder.Entity<BookingRecord>(entity =>
            {
               
                entity.HasKey(b => b.BookingId);
                entity.HasOne<Employee>().WithMany().HasForeignKey(b => b.EmployeeId).IsRequired();
                entity.HasOne<Resource>().WithMany().HasForeignKey(b => b.ResourceId).IsRequired();
                entity.Property(b => b.StartDateTime).IsRequired();
                entity.Property(b => b.EndDateTime).IsRequired();
                
            });
        }

       

    }
}
