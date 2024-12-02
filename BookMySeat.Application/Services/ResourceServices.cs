using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Application.Interfaces;
using AGData.BookMySeat.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGData.BookMySeat.Application.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;

        public ResourceService(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository ?? throw new ArgumentNullException(nameof(resourceRepository));
        }

        public async Task<Guid> AddResourceAsync(Resource resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource), "Resource cannot be null.");
            }

            if (string.IsNullOrEmpty(resource.ResourceName))
            {
                throw new ArgumentException("Resource name cannot be null or empty.", nameof(resource.ResourceName));
            }

            if (string.IsNullOrEmpty(resource.ResourceCategorey))
            {
                throw new ArgumentException("Resource category cannot be null or empty.", nameof(resource.ResourceCategorey));
            }

            return await _resourceRepository.AddResourceAsync(resource);
        }

        public async Task<Guid> UpdateResourceAsync(Guid resourceId, string? updatedResourceName = null, string? updatedResourceCategory = null)
        {
            if (resourceId == Guid.Empty)
            {
                throw new ArgumentException("Resource ID cannot be empty.", nameof(resourceId));
            }

            var existingResource = await _resourceRepository.GetResourceByIdAsync(resourceId);
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

            return await _resourceRepository.UpdateResourceAsync(resourceId, updatedResourceName, updatedResourceCategory);
        }

        public async Task<Guid> DeleteResourceAsync(Guid resourceId)
        {
            if (resourceId == Guid.Empty)
            {
                throw new ArgumentException("Resource ID cannot be empty.", nameof(resourceId));
            }

            var resource = await _resourceRepository.GetResourceByIdAsync(resourceId);
            if (resource == null)
            {
                throw new InvalidOperationException("Resource not found.");
            }

            return await _resourceRepository.DeleteResourceAsync(resourceId);
        }

        public async Task<Resource> GetResourceByIdAsync(Guid resourceId)
        {
            if (resourceId == Guid.Empty)
            {
                throw new ArgumentException("Resource ID cannot be empty.", nameof(resourceId));
            }

            return await _resourceRepository.GetResourceByIdAsync(resourceId);
        }

        public async Task<IEnumerable<Resource>> GetAllResourcesAsync()
        {
            return await _resourceRepository.GetAllResourcesAsync();
        }
    }
}
