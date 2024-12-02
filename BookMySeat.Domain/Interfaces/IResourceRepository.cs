using AGData.BookMySeat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGData.BookMySeat.Domain.Interfaces
{
    public interface IResourceRepository
    {
        Task<IEnumerable<Resource>> GetAllResourcesAsync();
        Task<Resource> GetResourceByIdAsync(Guid resourceId);
        Task<Guid> AddResourceAsync(Resource resource);
        Task<Guid> UpdateResourceAsync(Guid resourceId, string? updatedResourceCategory = null, string? updatedResourceName = null);
        Task<Guid> DeleteResourceAsync(Guid resourceId);
    }
}
