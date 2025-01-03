namespace AGData.BookMySeat.Domain.Entities
{
    public class BookingRecord
    {
        public Guid BookingId { get; private set; }
        public Guid EmployeeId { get; private set; }
        public Guid ResourceId { get; private set; }
        public DateTime BookingDate { get; private set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }

        private BookingRecord() { }

        public BookingRecord(Guid employeeId, Guid resourceId, DateTime bookingDate, DateTime startDateTime, DateTime endDateTime)
        {
            BookingId = Guid.NewGuid();
            EmployeeId = employeeId;
            ResourceId = resourceId;
            BookingDate = bookingDate;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }

        public void UpdateBookingDates(DateTime newStartDateTime, DateTime newEndDateTime)
        {
            if (newStartDateTime < newEndDateTime)
            {
                StartDateTime = newStartDateTime;
                EndDateTime = newEndDateTime;
            }
        }
    }
}
