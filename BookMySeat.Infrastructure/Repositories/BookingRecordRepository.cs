using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Domain.Interfaces;
using AGData.BookMySeat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AGData.BookMySeat.Infrastructure.Repositories
{
    public class BookingRecordRepository : IBookingRepository
    {
        private readonly SeatBookingDbcontext _dbContext;

        public BookingRecordRepository(SeatBookingDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddBookingRecordAsync(BookingRecord bookingRecord)
        {
            bookingRecord.BookingId = Guid.NewGuid();
            _dbContext.BookingRecords.Add(bookingRecord);
            await _dbContext.SaveChangesAsync();
            return bookingRecord.BookingId;
        }

        public async Task<Guid> UpdateBookingRecordAsync(
            Guid bookingId,
            DateTime? updatedStartDateTime = null,
            DateTime? updatedEndDateTime = null,
            Guid? updatedResourceId = null)
        {
            var booking = await _dbContext.BookingRecords
                .FirstOrDefaultAsync(b => b.BookingId == bookingId);

            if (booking == null)
                throw new KeyNotFoundException($"Booking record with ID {bookingId} not found.");

            if (updatedStartDateTime.HasValue)
                booking.StartDateTime = updatedStartDateTime.Value;

            if (updatedEndDateTime.HasValue)
                booking.EndDateTime = updatedEndDateTime.Value;

            if (updatedResourceId.HasValue)
                booking.ResourceId = updatedResourceId.Value;

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
            {
                throw new KeyNotFoundException($"Booking record with ID {bookingId} not found.");
            }

            return bookingRecord;
        }
    }
}
