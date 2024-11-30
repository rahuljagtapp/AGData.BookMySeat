namespace AGData.BookMySeat.Domain.Entities
{
    public class Resource
    {

        public Guid ResourceId { get; set; } //ResourceId is immutable

        public string ResourceCategorey { get; set; } // ResourceType is immutable

        public string ResourceName { get; set; } // ResourceName is immutable


        //public Resource(string resourceType, string resourceName)
        //{
        //    ResourceId = Guid.NewGuid();
        //    ResourceCategorey = resourceType;
        //    ResourceName = resourceName;

        //}
        public Resource() {}
        

    }
}
