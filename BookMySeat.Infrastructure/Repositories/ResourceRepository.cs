using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Domain.Interfaces;
using AGData.BookMySeat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGData.BookMySeat.Infrastructure.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly SeatBookingDbcontext _dbContext;

        public ResourceRepository(SeatBookingDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Resource>> GetAllResourcesAsync()
        {
            return await _dbContext.Resources.ToListAsync();
        }

        public async Task<Resource> GetResourceByIdAsync(Guid resourceId)
        {
            var resource = await _dbContext.Resources
                .FirstOrDefaultAsync(r => r.ResourceId == resourceId);

            if (resource == null)
            {
                throw new KeyNotFoundException($"Resource with ID {resourceId} was not found.");
            }

            return resource;
        }

        public async Task<Guid> AddResourceAsync(Resource resource)
        {
            resource.ResourceId = Guid.NewGuid();
            await _dbContext.Resources.AddAsync(resource);
            await _dbContext.SaveChangesAsync();

            return resource.ResourceId;
        }

        public async Task<Guid> UpdateResourceAsync(Guid resourceId, string? updatedResourceCategory = null, string? updatedResourceName = null)
        {
            if (resourceId == Guid.Empty)
                throw new ArgumentException("Resource ID cannot be empty.", nameof(resourceId));

            var existingResource = await _dbContext.Resources
                .FirstOrDefaultAsync(r => r.ResourceId == resourceId);

            if (existingResource == null)
                throw new InvalidOperationException("Resource not found.");

            if (!string.IsNullOrEmpty(updatedResourceCategory))
            {
                existingResource.ResourceCategorey = updatedResourceCategory;
            }

            if (!string.IsNullOrEmpty(updatedResourceName))
            {
                existingResource.ResourceName = updatedResourceName;
            }

            await _dbContext.SaveChangesAsync();

            return existingResource.ResourceId;
        }

        public async Task<Guid> DeleteResourceAsync(Guid resourceId)
        {
            var resource = await _dbContext.Resources
                .FirstOrDefaultAsync(r => r.ResourceId == resourceId);

            if (resource != null)
            {
                _dbContext.Resources.Remove(resource);
                await _dbContext.SaveChangesAsync();
                return resource.ResourceId;
            }

            return Guid.Empty;
        }
    }
}
