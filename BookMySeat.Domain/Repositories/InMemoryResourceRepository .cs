//using AGData.BookMySeat.Domain.Entities;
//using AGData.BookMySeat.Domain.Interfaces;

//namespace AGData.BookMySeat.Domain.Repositories
//{
//    public class InMemoryResourceRepository : IResourceRepository
//    {
//        private readonly List<Resource> _resourcesList = new List<Resource>();

//        public Guid AddResource(Resource resource)
//        {
//            _resourcesList.Add(resource);
//            return  resource.ResourceId;
//        }

//        public string UpdateResource(Guid resourceId, string? updatedResourceName = null, string? updatedResourceCategory = null)
//        {
//            var existingResource = _resourcesList.FirstOrDefault(r => r.ResourceId == resourceId);
//            if (existingResource == null)
//            {
//                throw new InvalidOperationException("Resource not found.");
//            }

//            if (!string.IsNullOrEmpty(updatedResourceName))
//            {
//                existingResource.ResourceName = updatedResourceName;
//            }

//            if (!string.IsNullOrEmpty(updatedResourceCategory))
//            {
//                existingResource.ResourceCategorey = updatedResourceCategory;
//            }

//            return "Resource updated successfully.";
//        }

//        public string DeleteResource(Guid resourceId)
//        {
//            var resourceToDelete = _resourcesList.FirstOrDefault(r => r.ResourceId == resourceId);
//            if (resourceToDelete == null)
//            {
//                throw new InvalidOperationException("Resource not found.");
//            }

//            _resourcesList.Remove(resourceToDelete);
//            return "Resource deleted successfully.";
//        }

//        public Resource GetResourceById(Guid resourceId)
//        {
//            var resource = _resourcesList.FirstOrDefault(r => r.ResourceId == resourceId);
//            if (resource == null)
//            {
//                throw new KeyNotFoundException("Resource not found.");
//            }

//            return resource;
//        }

//        public IEnumerable<Resource> GetAllResources()
//        {
//            return _resourcesList;
//        }
//    }
//}
