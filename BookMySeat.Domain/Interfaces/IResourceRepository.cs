using AGData.BookMySeat.Domain.Entities;

namespace AGData.BookMySeat.Domain.Interfaces
{
    public interface IResourceRepository
    {

        Task<IEnumerable<Resource>> GetAllResourcesAsync();
        Task<Resource> GetResourceByIdAsync(Guid resourceId);
        Task<Resource> AddResourceAsync(Resource resource);
        Task<Resource> UpdateResourceAsync(Guid resourceId, Resource resource);
        Task<bool> DeleteResourceAsync(Guid resourceId);

        //Guid AddResource(Resource resource);
        //string UpdateResource(Guid resourceId, string? updatedResourceName = null, string? updatedResourceCategory = null);
        //string DeleteResource(Guid resourceId);
        //Resource GetResourceById(Guid resourceId);
        //IEnumerable<Resource> GetAllResources();
    }
}
