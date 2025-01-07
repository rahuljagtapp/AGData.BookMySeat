using AGData.BookMySeat.Domain.Entities;

namespace AGData.BookMySeat.Application.Interfaces
{
    public interface ISeatService
    {
        Task<Guid> AddSeatAsync(Seat seat);
        Task<Guid> UpdateSeatAsync(Guid seatId, string? updatedSeatName = null);
        Task<Guid> DeleteSeatAsync(Guid seatId);
        Task<IEnumerable<Seat>> GetAllSeatsAsync();
        Task<Seat> GetSeatByIdAsync(Guid seatId);
    }
}
