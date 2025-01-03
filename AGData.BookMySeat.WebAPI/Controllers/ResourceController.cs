using AGData.BookMySeat.Application.Interfaces;
using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.WebAPI.CustomActionFilter;
using AGData.BookMySeat.WebAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AGData.BookMySeat.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService)
        {
            _resourceService=resourceService ?? throw new ArgumentNullException(nameof(resourceService));
        }

        [HttpGet("id:Guid")]
        [ValidateModel]
        public async Task<IActionResult> GetResourceByIdAsync(Guid id)
        {
            var resource = await _resourceService.GetResourceByIdAsync(id);
            if(resource==null)
            {
                return NotFound("Resource Not Found");
            }

            return Ok(new AddResourceRequestDto
            {
                ResourceId = resource.ResourceId,
                ResourceName=resource.ResourceName,
                ResourceCategorey=resource.ResourceCategorey

            });

        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddResourceAsync([FromBody] AddResourceRequestDto resourceDto) {
        
                var newResource = new Resource
                {
                    ResourceId = Guid.NewGuid(),
                    ResourceName = resourceDto.ResourceName,
                    ResourceCategorey = resourceDto.ResourceCategorey
                };

                var addedResourceId=await _resourceService.AddResourceAsync(newResource);
                return CreatedAtAction("GetResourceById", new { id = addedResourceId }, addedResourceId);


        }

        [HttpPut]
        [ValidateModel]
        public async Task<IActionResult> UpdateResourceAsync(Guid Id, [FromBody] UpdateResourceRequestDto updatedResourceDto)
        {
            var updatedResourceId = await _resourceService.UpdateResourceAsync(Id, updatedResourceDto.ResourceName,
                updatedResourceDto.ResourceCategory);
            return Ok(updatedResourceId);
        }

        [HttpDelete("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> DeleteResourceAsync(Guid id)
        {
            await _resourceService.DeleteResourceAsync(id);
            return Ok( new{ id});

        }



        [HttpGet("all")]
        public async Task<IActionResult> GetAllResourcesAsync()
        {
            var resources = await _resourceService.GetAllResourcesAsync();
            var resourceDtos = resources.Select(r => new AddResourceRequestDto
            {
                ResourceId = r.ResourceId,
                ResourceName = r.ResourceName,
                ResourceCategorey = r.ResourceCategorey
              
            }).ToList();

            return Ok(resourceDtos);
        }

    }
}
