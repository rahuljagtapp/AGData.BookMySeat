using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Domain.Interfaces;
using AGData.BookMySeat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AGData.BookMySeat.Infrastructure.Repositories
{
    public class BookingRecordRepository : IBookingRepository
    {
        private readonly SeatBookingDbContext _dbContext;

        public BookingRecordRepository(SeatBookingDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Guid> AddBookingRecordAsync(BookingRecord bookingRecord)
        {
           
            await _dbContext.BookingRecords.AddAsync(bookingRecord);
            await _dbContext.SaveChangesAsync();
            return bookingRecord.BookingId;
        }

        public async Task<Guid> UpdateBookingRecordAsync(
    Guid bookingId,
    DateTime? updatedStartDateTime = null,
    DateTime? updatedEndDateTime = null,
    Guid? updatedSeatId = null)
        {
            var booking = await _dbContext.BookingRecords
                .FirstOrDefaultAsync(b => b.BookingId == bookingId);

            if (booking == null)
                throw new KeyNotFoundException($"Booking record with ID {bookingId} not found.");

            if (updatedStartDateTime.HasValue && updatedEndDateTime.HasValue)
            {
                booking.UpdateBookingDates(updatedStartDateTime.Value, updatedEndDateTime.Value);
            }
            else
            {
                if (updatedStartDateTime.HasValue)
                    booking.UpdateBookingDates(updatedStartDateTime.Value, booking.EndDateTime);

                if (updatedEndDateTime.HasValue)
                    booking.UpdateBookingDates(booking.StartDateTime, updatedEndDateTime.Value);
            }

            if (updatedSeatId.HasValue)
            {
                booking.UpdateSeat(updatedSeatId.Value);
            }

            await _dbContext.SaveChangesAsync();
            return booking.BookingId;
        }


        public async Task<Guid> DeleteBookingRecordAsync(Guid bookingId)
        {
            var booking = await _dbContext.BookingRecords
                .FirstOrDefaultAsync(b => b.BookingId == bookingId);

            if (booking == null)
                throw new KeyNotFoundException($"Booking record with ID {bookingId} not found.");

            _dbContext.BookingRecords.Remove(booking);
            await _dbContext.SaveChangesAsync();
            return booking.BookingId;
        }

        public async Task<IEnumerable<BookingRecord>> GetAllBookingRecordsAsync()
        {
            return await _dbContext.BookingRecords.ToListAsync();
        }

        public async Task<BookingRecord> GetBookingRecordByIdAsync(Guid bookingId)
        {
            var bookingRecord = await _dbContext.BookingRecords
                .FirstOrDefaultAsync(b => b.BookingId == bookingId);

            if (bookingRecord == null)
                throw new KeyNotFoundException($"Booking record with ID {bookingId} not found.");

            return bookingRecord;
        }
    }
}
