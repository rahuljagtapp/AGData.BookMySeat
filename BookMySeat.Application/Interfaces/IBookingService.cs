using AGData.BookMySeat.Domain.Entities;

namespace AGData.BookMySeat.Application.Interfaces
{
    public interface IBookingService
    {


        Task<Guid> AddBookingAsync(BookingRecord booking);
        Task<string> UpdateBookingAsync(Guid bookingId, DateTime? updatedStartDateTime = null, DateTime? updatedEndDateTime = null, Guid? updatedResourceId = null);
        Task<string> DeleteBookingAsync(Guid bookingId);
        Task<IEnumerable<BookingRecord>> GetAllBookingsAsync();
        Task<BookingRecord> GetBookingByIdAsync(Guid bookingId);

        //Guid AddBooking(BookingRecord booking);
        //string UpdateBooking(Guid bookingId, DateTime? updatedStartDateTime = null, DateTime? updatedEndDateTime = null, Guid? updatedResourceId = null);
        //string DeleteBooking(Guid bookingId);
        //IEnumerable<BookingRecord> GetAllBookings();
        //BookingRecord GetBookingById(Guid bookingId);
    }
}
