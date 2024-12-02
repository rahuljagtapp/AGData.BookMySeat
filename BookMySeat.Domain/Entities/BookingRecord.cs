namespace AGData.BookMySeat.Domain.Entities
{
    public class BookingRecord
    {

        public Guid BookingId { get; set; }



        public Guid EmployeeId { get;  set; }
        public Guid ResourceId { get; set; }
        public DateTime BookingDate { get;  set; }

        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public BookingRecord() { }


    }
}
