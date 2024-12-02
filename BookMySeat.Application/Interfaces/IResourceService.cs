using AGData.BookMySeat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGData.BookMySeat.Application.Interfaces
{
    public interface IResourceService
    {
        Task<Guid> AddResourceAsync(Resource resource);
        Task<Guid> UpdateResourceAsync(Guid resourceId, string? updatedResourceName = null, string? updatedResourceCategory = null);
        Task<Guid> DeleteResourceAsync(Guid resourceId);
        Task<IEnumerable<Resource>> GetAllResourcesAsync();
        Task<Resource> GetResourceByIdAsync(Guid resourceId);
    }
}
