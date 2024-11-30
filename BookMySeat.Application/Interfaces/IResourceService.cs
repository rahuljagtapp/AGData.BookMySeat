using AGData.BookMySeat.Domain.Entities;

namespace AGData.BookMySeat.Application.Interfaces
{
    public interface IResourceService
    {
        Guid AddResource(Resource resource);
        string UpdateResource(Guid resourceId, string? updatedResourceName = null, string? updatedResourceCategory = null);
        string DeleteResource(Guid resourceId);
        IEnumerable<Resource> GetAllResources();
        Resource GetResourceById(Guid resourceId);
    }
}
