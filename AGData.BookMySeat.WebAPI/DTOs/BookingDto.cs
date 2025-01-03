namespace AGData.BookMySeat.WebAPI.DTOs
{
    public class BookingDto
    {
        public Guid BookingId { get; set; }
        public Guid ResourceId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
