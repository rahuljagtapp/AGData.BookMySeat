namespace AGData.BookMySeat.WebAPI.DTOs
{
    public class BookingDto
    {
        public Guid BookingId { get; set; }
        public Guid SeatId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
