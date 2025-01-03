namespace AGData.BookMySeat.WebAPI.DTOs
{
    public class AddBookingRequestDto
    {
        public Guid ResourceId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
