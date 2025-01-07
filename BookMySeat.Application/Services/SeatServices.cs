using AGData.BookMySeat.Domain.Entities;
using AGData.BookMySeat.Application.Interfaces;
using AGData.BookMySeat.Domain.Interfaces;

namespace AGData.BookMySeat.Application.Services
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository _seatRepository;

        public SeatService(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository ?? throw new ArgumentNullException(nameof(seatRepository));
        }

        public async Task<Guid> AddSeatAsync(Seat seat)
        {
            if (seat == null)
            {
                throw new ArgumentNullException(nameof(seat), "Seat cannot be null.");
            }

            if (string.IsNullOrEmpty(seat.SeatName))
            {
                throw new ArgumentException("Seat name cannot be null or empty.", nameof(seat.SeatName));
            }

            return await _seatRepository.AddSeatAsync(seat);
        }

        public async Task<Guid> UpdateSeatAsync(Guid seatId, string? updatedSeatName = null)
        {
            if (seatId == Guid.Empty)
            {
                throw new ArgumentException("Seat ID cannot be empty.", nameof(seatId));
            }

            var existingSeat = await _seatRepository.GetSeatByIdAsync(seatId);
            if (existingSeat == null)
            {
                throw new InvalidOperationException("Seat not found.");
            }

            if (!string.IsNullOrEmpty(updatedSeatName))
            {
                existingSeat.UpdateSeatName(updatedSeatName);
            }

            return await _seatRepository.UpdateSeatAsync(seatId, updatedSeatName);
        }

        public async Task<Guid> DeleteSeatAsync(Guid seatId)
        {
            if (seatId == Guid.Empty)
            {
                throw new ArgumentException("Seat ID cannot be empty.", nameof(seatId));
            }

            var seat = await _seatRepository.GetSeatByIdAsync(seatId);
            if (seat == null)
            {
                throw new InvalidOperationException("Seat not found.");
            }

            return await _seatRepository.DeleteSeatAsync(seatId);
        }

        public async Task<Seat> GetSeatByIdAsync(Guid seatId)
        {
            if (seatId == Guid.Empty)
            {
                throw new ArgumentException("Seat ID cannot be empty.", nameof(seatId));
            }

            return await _seatRepository.GetSeatByIdAsync(seatId);
        }

        public async Task<IEnumerable<Seat>> GetAllSeatsAsync()
        {
            return await _seatRepository.GetAllSeatsAsync();
        }
    }
}
