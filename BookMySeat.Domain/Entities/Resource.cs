namespace AGData.BookMySeat.Domain.Entities
{
    public class Resource
    {

        public Guid ResourceId { get; set; } //ResourceId is immutable

        public string ResourceCategorey { get; set; } 

        public string ResourceName { get; set; } 


        //public Resource(string resourceType, string resourceName)
        //{
        //    ResourceId = Guid.NewGuid();
        //    ResourceCategorey = resourceType;
        //    ResourceName = resourceName;

        //}
        public Resource() {}
        

    }
}
