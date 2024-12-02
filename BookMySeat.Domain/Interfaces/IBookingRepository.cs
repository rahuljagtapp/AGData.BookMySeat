using AGData.BookMySeat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGData.BookMySeat.Domain.Interfaces
{
    public interface IBookingRepository
    {
        Task<Guid> AddBookingRecordAsync(BookingRecord bookingRecord);

        Task<Guid> UpdateBookingRecordAsync(
            Guid bookingId,
            DateTime? updatedStartDateTime = null,
            DateTime? updatedEndDateTime = null,
            Guid? updatedResourceId = null);

        Task<Guid> DeleteBookingRecordAsync(Guid bookingId);

        Task<IEnumerable<BookingRecord>> GetAllBookingRecordsAsync();

        Task<BookingRecord> GetBookingRecordByIdAsync(Guid bookingId);
    }
}
