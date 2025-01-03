namespace AGData.BookMySeat.WebAPI.DTOs
{
    public class AddResourceRequestDto
    {
        public Guid ResourceId { get; set; } //ResourceId is immutable

        public string ResourceCategorey { get; set; }

        public string ResourceName { get; set; }
    }
}
