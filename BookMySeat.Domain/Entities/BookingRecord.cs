namespace AGData.BookMySeat.Domain.Entities
{
    public class BookingRecord
    {

        public Guid BookingId { get; set; }
        public Guid EmployeeId { get; private set; }
        public Guid ResourceId { get; set; }
        public DateTime BookingDate { get;  set; }

        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        //public BookingRecord(Guid employeeId, Guid resourceId, DateTime bookingDate, DateTime startDateTime, DateTime endDateTime)
        //{


        //    BookingId = Guid.NewGuid();
        //    EmployeeId = employeeId;
        //    ResourceId = resourceId;
        //    BookingDate = bookingDate;
        //    StartDateTime = startDateTime;
        //    EndDateTime = endDateTime;
        //}
        public BookingRecord() { }


    }
}
