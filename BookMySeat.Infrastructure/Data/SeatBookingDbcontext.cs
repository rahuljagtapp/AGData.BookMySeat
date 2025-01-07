using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AGData.BookMySeat.Infrastructure.Data
{
    public class SeatBookingDbContext : DbContext, ISeatBookingDbContext
    {
        public SeatBookingDbContext(DbContextOptions<SeatBookingDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<BookingRecord> BookingRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);
                entity.Property(e => e.EmployeeId)
                    .HasDefaultValueSql("NEWID()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EmployeeRole)
                    .HasConversion<string>()
                    .IsRequired();
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.HasKey(s => s.SeatId);
                entity.Property(s => s.SeatId)
                    .HasDefaultValueSql("NEWID()")
                    .ValueGeneratedOnAdd();

                entity.Property(s => s.SeatName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Visitor>(entity =>
            {
                entity.HasKey(v => v.VisitorId);
                entity.Property(v => v.VisitorId)
                    .HasDefaultValueSql("NEWID()")
                    .ValueGeneratedOnAdd();

                entity.HasOne<Employee>()
                    .WithMany()
                    .HasForeignKey(v => v.HostEmployeeId)
                    .IsRequired();

                entity.Property(v => v.HostEmployee)
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<BookingRecord>(entity =>
            {
                entity.HasKey(b => b.BookingId);
                entity.Property(b => b.BookingId)
                    .HasDefaultValueSql("NEWID()")
                    .ValueGeneratedOnAdd();

                entity.HasOne<Employee>()
                    .WithMany()
                    .HasForeignKey(b => b.EmployeeId)
                    .IsRequired();

                entity.HasOne<Seat>()
                    .WithMany()
                    .HasForeignKey(b => b.SeatId)
                    .IsRequired();

                entity.Property(b => b.StartDateTime)
                    .IsRequired();

                entity.Property(b => b.EndDateTime)
                    .IsRequired();
            });
        }
    }
}
