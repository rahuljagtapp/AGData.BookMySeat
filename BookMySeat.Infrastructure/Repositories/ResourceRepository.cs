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

        public async Task<Resource> AddResourceAsync(Resource resource)
        {
            resource.ResourceId = Guid.NewGuid();  // Generate a new ID for the resource
            await _dbContext.Resources.AddAsync(resource);
            await _dbContext.SaveChangesAsync();

            return resource;
        }

        public async Task<Resource> UpdateResourceAsync(Guid resourceId, Resource resource)
        {
            var existingResource = await _dbContext.Resources
                .FirstOrDefaultAsync(r => r.ResourceId == resourceId);

            if (existingResource != null)
            {
                existingResource.ResourceCategorey = resource.ResourceCategorey;
                existingResource.ResourceName = resource.ResourceName;

                await _dbContext.SaveChangesAsync();
                return existingResource;
            }

            return null;
        }

        public async Task<bool> DeleteResourceAsync(Guid resourceId)
        {
            var resource = await _dbContext.Resources
                .FirstOrDefaultAsync(r => r.ResourceId == resourceId);

            if (resource != null)
            {
                _dbContext.Resources.Remove(resource);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
