using AGData.BookMySeat.Domain.Entities;

namespace AGData.BookMySeat.Application.Interfaces
{
    public interface IBookingService
    {
        Task<Guid> AddBookingAsync(BookingRecord booking);
        Task<Guid> UpdateBookingAsync(Guid bookingId, DateTime? updatedStartDateTime = null, DateTime? updatedEndDateTime = null, Guid? updatedResourceId = null);
        Task<Guid> DeleteBookingAsync(Guid bookingId);
        Task<IEnumerable<BookingRecord>> GetAllBookingsAsync();
        Task<BookingRecord> GetBookingByIdAsync(Guid bookingId);
    }
}
