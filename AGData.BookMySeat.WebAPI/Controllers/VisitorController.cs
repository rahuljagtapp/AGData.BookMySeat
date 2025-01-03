using AGData.BookMySeat.Application.Interfaces;
using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.WebAPI.CustomActionFilter;
using AGData.BookMySeat.WebAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGData.BookMySeat.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly IVisitorService _visitorService;

        public VisitorController(IVisitorService visitorService)
        {
            _visitorService = visitorService ?? throw new ArgumentNullException(nameof(visitorService));
        }

        // Get a visitor by ID
        [HttpGet("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> GetVisitorByIdAsync(Guid id)
        {
            var visitor = await _visitorService.GetVisitorByIdAsync(id, currentUser: null); // Assuming `currentUser` is provided here, adjust as necessary
            if (visitor == null) return NotFound("Visitor not found.");

            return Ok(new VisitorDto
            {
                VisitorId = visitor.VisitorId,
                VisitorName = visitor.VisitorName,
                HostEmployee = visitor.HostEmployee
            });
        }

        // Add a new visitor
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddVisitorAsync([FromBody] AddVisitorRequestDto newVisitorDto, [FromQuery] Employee currentUser)
        {
            var newVisitor = new Visitor
            {
                VisitorId = Guid.NewGuid(),
                VisitorName = newVisitorDto.VisitorName,
                HostEmployee = newVisitorDto.HostEmployee
            };

            var addedVisitorId = await _visitorService.AddVisitorAsync(newVisitor, currentUser);
            return CreatedAtAction("GetVisitorById", new { id = addedVisitorId }, addedVisitorId);
        }

        // Update an existing visitor
        [HttpPut("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateVisitorAsync(Guid id, [FromBody] UpdateVisitorRequestDto updatedVisitorDto, [FromQuery] Employee currentUser)
        {
            var updatedVisitorId = await _visitorService.UpdateVisitorAsync(currentUser, id, updatedVisitorDto.VisitorName, updatedVisitorDto.HostEmployee);
            return Ok(updatedVisitorId);
        }

        // Delete a visitor
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteVisitorAsync(Guid id, [FromQuery] Employee currentUser)
        {
            await _visitorService.DeleteVisitorAsync(id, currentUser);
            return NoContent();
        }

        // Get all visitors
        [HttpGet("all")]
        public async Task<IActionResult> GetAllVisitorsAsync([FromQuery] Employee currentUser)
        {
            var visitors = await _visitorService.GetAllVisitorsAsync(currentUser);
            var visitorDtos = visitors.Select(v => new VisitorDto
            {
                VisitorId = v.VisitorId,
                VisitorName = v.VisitorName,
                HostEmployee = v.HostEmployee
            }).ToList();

            return Ok(visitorDtos);
        }
    }
}

