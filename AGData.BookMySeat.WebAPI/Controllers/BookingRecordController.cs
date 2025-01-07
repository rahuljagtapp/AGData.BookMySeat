using AGData.BookMySeat.Application.Interfaces;
using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.WebAPI.CustomActionFilter;
using AGData.BookMySeat.WebAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AGData.BookMySeat.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingRecordController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingRecordController(IBookingService bookingService)
        {
            _bookingService = bookingService ?? throw new ArgumentNullException(nameof(bookingService));
        }

        // Add a new booking
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddBookingAsync([FromBody] AddBookingRequestDto newBookingDto)
        {
            if (newBookingDto == null)
                return BadRequest("Invalid booking data.");

            var newBooking = new BookingRecord
              (
                newBookingDto.EmployeeId,
                newBookingDto.SeatId,
                newBookingDto.StartDateTime,
                newBookingDto.EndDateTime
            );

            var addedBookingId = await _bookingService.AddBookingAsync(newBooking);
            return CreatedAtAction("GetBookingById", new { id = addedBookingId }, addedBookingId);
        }

        // Get a booking by ID
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetBookingByIdAsync(Guid id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null) return NotFound("Booking not found.");

            return Ok(new BookingDto
            {
                BookingId = booking.BookingId,
                EmployeeId = booking.EmployeeId,
                SeatId = booking.SeatId,
                StartDateTime = booking.StartDateTime,
                EndDateTime = booking.EndDateTime
            });
        }

        // Update a booking
        [HttpPut("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateBookingAsync(Guid id, [FromBody] UpdateBookingRequestDto updatedBookingDto)
        {
            if (updatedBookingDto == null)
                return BadRequest("Invalid update data.");

            var updatedBookingId = await _bookingService.UpdateBookingAsync(
                id,
                updatedBookingDto.StartDateTime,
                updatedBookingDto.EndDateTime,
                updatedBookingDto.ResourceId);

            return Ok(new { BookingId = updatedBookingId });
        }

        // Delete a booking
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteBookingAsync(Guid id)
        {
            await _bookingService.DeleteBookingAsync(id);
            return NoContent();
        }

        // Get all bookings
        [HttpGet("all")]
        public async Task<IActionResult> GetAllBookingsAsync()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            var bookingDtos = bookings.Select(b => new BookingDto
            {
                BookingId = b.BookingId,
                EmployeeId = b.EmployeeId,
                SeatId = b.SeatId,
                StartDateTime = b.StartDateTime,
                EndDateTime = b.EndDateTime
            }).ToList();

            return Ok(bookingDtos);
        }
    }
}

