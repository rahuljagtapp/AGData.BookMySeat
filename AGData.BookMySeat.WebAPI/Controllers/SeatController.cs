using AGData.BookMySeat.Application.Interfaces;
using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.WebAPI.CustomActionFilter;
using AGData.BookMySeat.WebAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AGData.BookMySeat.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _seatService;

        public SeatController(ISeatService seatService)
        {
            _seatService = seatService ?? throw new ArgumentNullException(nameof(seatService));
        }

        // Get a seat by its ID
        [HttpGet("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> GetSeatByIdAsync(Guid id)
        {
            var seat = await _seatService.GetSeatByIdAsync(id);
            if (seat == null)
            {
                return NotFound("Seat Not Found");
            }

            return Ok(new AddSeatRequestDto
            {
                SeatId = seat.SeatId,
                SeatName = seat.SeatName
            });
        }

        // Add a new seat
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddSeatAsync([FromBody] AddSeatRequestDto seatDto)
        {
            var newSeat = new Seat
            (seatDto.SeatName);
               
           

            var addedSeatId = await _seatService.AddSeatAsync(newSeat);
            return CreatedAtAction("GetSeatById", new { id = addedSeatId }, addedSeatId);
        }

        // Update an existing seat's name
        [HttpPut("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateSeatAsync(Guid id, [FromBody] UpdateSeatRequestDto updatedSeatDto)
        {
            var updatedSeatId = await _seatService.UpdateSeatAsync(id, updatedSeatDto.SeatName);
            return Ok(updatedSeatId);
        }

        // Delete a seat
        [HttpDelete("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> DeleteSeatAsync(Guid id)
        {
            await _seatService.DeleteSeatAsync(id);
            return Ok(new { id });
        }

        // Get all seats
        [HttpGet("all")]
        public async Task<IActionResult> GetAllSeatsAsync()
        {
            var seats = await _seatService.GetAllSeatsAsync();
            var seatDtos = seats.Select(s => new AddSeatRequestDto
            {
                SeatId = s.SeatId,
                SeatName = s.SeatName
            }).ToList();

            return Ok(seatDtos);
        }
    }
}
