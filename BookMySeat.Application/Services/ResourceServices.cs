using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Application.Interfaces;
using AGData.BookMySeat.Domain.Interfaces;
using System.Security.AccessControl;

namespace AGData.BookMySeat.Application.Services
{
    public class ResourceService:IResourceService
    {
        private readonly IResourceRepository _resourceRepository;

        public ResourceService(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository ?? throw new ArgumentNullException(nameof(resourceRepository));
        }

        public Guid AddResource(Resource resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException("Resource cannot be null.");
            }
            if (string.IsNullOrEmpty(resource.ResourceName))
            {
                throw new ArgumentNullException("Resource name cannot be null");
            }

            return _resourceRepository.AddResource(resource);
        }

        public string UpdateResource(Guid resourceId, string? updatedResourceName = null, string? updatedResourceCategory = null)
        {
            if (resourceId == Guid.Empty)
            {
                throw new ArgumentException("Resource ID cannot be empty.", nameof(resourceId));
            }

            var existingResource = _resourceRepository.GetResourceById(resourceId);
            if (existingResource == null)
            {
                throw new InvalidOperationException("Resource not found.");
            }

            if (!string.IsNullOrEmpty(updatedResourceName))
            {
                existingResource.ResourceName = updatedResourceName;
            }

            if (!string.IsNullOrEmpty(updatedResourceCategory))
            {
                existingResource.ResourceCategorey = updatedResourceCategory;
            }

            return _resourceRepository.UpdateResource(resourceId,updatedResourceName,updatedResourceCategory);
        }

        public string DeleteResource(Guid resourceId)
        {
            if (resourceId == Guid.Empty)
            {
                throw new ArgumentException("ResourceId cannot be empty.", nameof(resourceId));
            }

            var resource = _resourceRepository.GetResourceById(resourceId);
            if (resource == null)
            {
                throw new InvalidOperationException("Resource not found.");
            }

            return _resourceRepository.DeleteResource(resourceId);
        }

        public Resource GetResourceById(Guid resourceId)
        {
            if (resourceId == Guid.Empty)
            {
                throw new ArgumentException("ResourceId cannot be empty.", nameof(resourceId));
            }

            return _resourceRepository.GetResourceById(resourceId);
        }

        public IEnumerable<Resource> GetAllResources()
        {
            return _resourceRepository.GetAllResources();
        }
    }
}
