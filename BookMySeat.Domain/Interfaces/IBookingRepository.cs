using AGData.BookMySeat.Domain.Entities;

namespace AGData.BookMySeat.Domain.Interfaces
{
    public interface IBookingRepository
    {

        Task<Guid> AddBookingRecordAsync(BookingRecord bookingRecord);
        Task<string> UpdateBookingRecordAsync(Guid bookingId, DateTime? updatedStartDateTime = null, DateTime? updatedEndDateTime = null, Guid? updatedResourceId = null);
        Task<string> DeleteBookingRecordAsync(Guid bookingId);
        Task<IEnumerable<BookingRecord>> GetAllBookingRecordsAsync();
        Task<BookingRecord> GetBookingRecordByIdAsync(Guid bookingId);

        //Guid AddBooking(BookingRecord bookingRecord);
        //string UpdateBooking(Guid bookingId, DateTime? updatedStartDateTime = null, DateTime? updatedEndDateTime = null, Guid? updatedResourceId = null);
        //string DeleteBooking(Guid bookingId);
        //IEnumerable<BookingRecord> GetAllBookings();
        //BookingRecord GetBookingById(Guid bookingId);
    }
}
