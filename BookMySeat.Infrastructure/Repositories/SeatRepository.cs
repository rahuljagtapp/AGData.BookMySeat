using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Domain.Interfaces;
using AGData.BookMySeat.Infrastructure.Data;
using AGData.BookMySeat.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGData.BookMySeat.Infrastructure.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly ISeatBookingDbContext _dbContext;

        public SeatRepository(SeatBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Seat>> GetAllSeatsAsync()
        {
            return await _dbContext.Seats.ToListAsync();
        }

        public async Task<Seat> GetSeatByIdAsync(Guid seatId)
        {
            var seat = await _dbContext.Seats
                .FirstOrDefaultAsync(s => s.SeatId == seatId);

            if (seat == null)
            {
                throw new KeyNotFoundException($"Seat with ID {seatId} was not found.");
            }

            return seat;
        }

        public async Task<Guid> AddSeatAsync(Seat seat)
        {
            if (seat == null)
            {
                throw new ArgumentNullException(nameof(seat), "Seat cannot be null.");
            }

            if (string.IsNullOrEmpty(seat.SeatName))
            {
                throw new ArgumentException("Seat name cannot be null or empty.", nameof(seat.SeatName));
            }

            _dbContext.Seats.Add(seat);
            await _dbContext.SaveChangesAsync();

            return seat.SeatId;  // EF Core handles the SeatId
        }

        public async Task<Guid> UpdateSeatAsync(Guid seatId, string? updatedSeatName = null)
        {
            if (seatId == Guid.Empty)
                throw new ArgumentException("Seat ID cannot be empty.", nameof(seatId));

            var existingSeat = await _dbContext.Seats
                .FirstOrDefaultAsync(s => s.SeatId == seatId);

            if (existingSeat == null)
                throw new InvalidOperationException("Seat not found.");

            if (!string.IsNullOrEmpty(updatedSeatName))
            {
                existingSeat.UpdateSeatName(updatedSeatName);
            }

            await _dbContext.SaveChangesAsync();

            return existingSeat.SeatId;
        }

        public async Task<Guid> DeleteSeatAsync(Guid seatId)
        {
            var seat = await _dbContext.Seats
                .FirstOrDefaultAsync(s => s.SeatId == seatId);

            if (seat != null)
            {
                _dbContext.Seats.Remove(seat);
                await _dbContext.SaveChangesAsync();
                return seat.SeatId;
            }

            return Guid.Empty;
        }
    }
}
