//using AGData.BookMySeat.Domain.Entities;
//using AGData.BookMySeat.Domain.Interfaces;

//namespace AGData.BookMySeat.Domain.Repositories
//{
//    public class InMemoryBookingRepository : IBookingRepository
//    {
//        private readonly List<BookingRecord> _bookingList = new List<BookingRecord>();

//        public Guid AddBooking(BookingRecord booking)
//        {
//            _bookingList.Add(booking);
//            return booking.BookingId;
//        }

//        public string UpdateBooking(Guid bookingId, DateTime? updatedStartDateTime = null, DateTime? updatedEndDateTime = null, Guid? updatedResourceId = null)
//        {
//            var existingBooking = _bookingList.FirstOrDefault(b => b.BookingId == bookingId);
//            if (existingBooking == null)
//            {
//                throw new InvalidOperationException("Booking not found.");
//            }

//            if (updatedStartDateTime.HasValue)
//            {
//                existingBooking.StartDateTime = updatedStartDateTime.Value;
//            }

//            if (updatedEndDateTime.HasValue)
//            {
//                existingBooking.EndDateTime = updatedEndDateTime.Value;
//            }

//            if (updatedResourceId.HasValue)
//            {
//                existingBooking.ResourceId = updatedResourceId.Value;
//            }

//            return "Booking updated successfully.";
//        }

//        public string DeleteBooking(Guid bookingId)
//        {
//            var bookingToDelete = _bookingList.FirstOrDefault(b => b.BookingId == bookingId);
//            if (bookingToDelete == null)
//            {
//                throw new InvalidOperationException("Booking not found.");
//            }
//            _bookingList.Remove(bookingToDelete);
//            return "Booking deleted successfully.";
//        }

//        public IEnumerable<BookingRecord> GetAllBookings()
//        {
//            return _bookingList;
//        }

//        public BookingRecord? GetBookingById(Guid bookingId)
//        {
//            return _bookingList.SingleOrDefault(b => b.BookingId == bookingId);
//        }
//    }
//}
