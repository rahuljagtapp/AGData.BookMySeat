namespace AGData.BookMySeat.Domain.Entities
{
    public class BookingRecord
    {
        public Guid BookingId { get; private set; }
        public Guid EmployeeId { get; private set; }
        public Guid SeatId { get; private set; }
        public DateTime BookingDate { get; private set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }

        public BookingRecord() { }

        public BookingRecord(Guid employeeId,Guid seatId,DateTime startDateTime, DateTime endDateTime)
        {

            EmployeeId = employeeId;
            SeatId = seatId;
            BookingDate = DateTime.Now;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }

        public void UpdateStartDate(DateTime newStartDateTime)
        {
            
                StartDateTime = newStartDateTime;  
            
        }
       public void UpdateBookingDates(DateTime newStartDateTime, DateTime newEndDateTime)
        {
            StartDateTime = newStartDateTime;
            EndDateTime= newEndDateTime;
        }

        public void UpdateEndDate(DateTime newEndDateTime)
        {
           
                EndDateTime = newEndDateTime;
        }
        public void UpdateSeat(Guid newSeatId)
        {
            SeatId = newSeatId;
        }
    }
}
