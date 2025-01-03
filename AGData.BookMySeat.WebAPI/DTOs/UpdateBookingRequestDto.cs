namespace AGData.BookMySeat.WebAPI.DTOs
{
    public class UpdateBookingRequestDto
    {
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public Guid? ResourceId { get; set; }

    }
}
