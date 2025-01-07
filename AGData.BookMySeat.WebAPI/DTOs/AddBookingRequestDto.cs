namespace AGData.BookMySeat.WebAPI.DTOs
{
    public class AddBookingRequestDto
    {
        public Guid SeatId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
