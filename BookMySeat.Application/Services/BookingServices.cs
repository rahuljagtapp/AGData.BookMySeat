using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Application.Interfaces;
using AGData.BookMySeat.Domain.Interfaces;

namespace AGData.BookMySeat.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
        }

        public async Task<Guid> AddBookingAsync(BookingRecord booking)
        {
            if (booking == null)
                throw new ArgumentNullException(nameof(booking), "Booking cannot be null.");

            return await _bookingRepository.AddBookingRecordAsync(booking);
        }

        public async Task<Guid> UpdateBookingAsync(Guid bookingId, DateTime? updatedStartDateTime = null, DateTime? updatedEndDateTime = null, Guid? updatedSeatId = null)
        {
            if (bookingId == Guid.Empty)
                throw new ArgumentException("Booking ID cannot be empty.", nameof(bookingId));

            var existingBooking = await _bookingRepository.GetBookingRecordByIdAsync(bookingId);
            if (existingBooking == null)
                throw new InvalidOperationException("Booking not found.");

            if (updatedStartDateTime.HasValue && updatedEndDateTime.HasValue)
            {
                if (updatedStartDateTime.Value >= updatedEndDateTime.Value)
                    throw new ArgumentException("Start date cannot be later than or equal to end date.");
            }

            if (updatedStartDateTime.HasValue && updatedStartDateTime.Value < DateTime.Now)
                throw new ArgumentException("Start date cannot be in the past.");

            if (updatedEndDateTime.HasValue && updatedEndDateTime.Value < DateTime.Now)
                throw new ArgumentException("End date cannot be in the past.");

            if (updatedSeatId.HasValue)
            {
                if (updatedSeatId.Value == Guid.Empty)
                    throw new ArgumentException("Resource ID cannot be empty.", nameof(updatedSeatId));

                var isResourceAvailable = !(await _bookingRepository.GetAllBookingRecordsAsync())
                    .Any(b =>
                        b.SeatId == updatedSeatId.Value && 
                        b.BookingId != bookingId &&
                        ((b.StartDateTime < (updatedEndDateTime ?? existingBooking.EndDateTime)) &&
                         (b.EndDateTime > (updatedStartDateTime ?? existingBooking.StartDateTime)))
                    );

                if (!isResourceAvailable)
                    throw new InvalidOperationException("The resource is not available during the specified time.");

                existingBooking.UpdateSeat(updatedSeatId.Value);
            }

            DateTime tempStartDateTime= updatedStartDateTime ?? existingBooking.StartDateTime;
            existingBooking.UpdateStartDate(tempStartDateTime);

            DateTime tempEndDateTime = updatedEndDateTime ?? existingBooking.EndDateTime;

            existingBooking.UpdateEndDate(tempEndDateTime);

            return await _bookingRepository.UpdateBookingRecordAsync(bookingId, updatedStartDateTime, updatedEndDateTime, updatedSeatId);
        }

        public async Task<Guid> DeleteBookingAsync(Guid bookingId)
        {
            if (bookingId == Guid.Empty)
                throw new ArgumentException("Booking ID cannot be empty.", nameof(bookingId));

            var existingBooking = await _bookingRepository.GetBookingRecordByIdAsync(bookingId);
            if (existingBooking == null)
                throw new InvalidOperationException("Booking not found.");

            return await _bookingRepository.DeleteBookingRecordAsync(bookingId);
        }

        public async Task<IEnumerable<BookingRecord>> GetAllBookingsAsync()
        {
            return await _bookingRepository.GetAllBookingRecordsAsync();
        }

        public async Task<BookingRecord> GetBookingByIdAsync(Guid bookingId)
        {
            if (bookingId == Guid.Empty)
                throw new ArgumentException("Booking ID cannot be empty.", nameof(bookingId));

            var booking = await _bookingRepository.GetBookingRecordByIdAsync(bookingId);
            if (booking == null)
                throw new InvalidOperationException("Booking not found.");

            return booking;
        }
    }
}
