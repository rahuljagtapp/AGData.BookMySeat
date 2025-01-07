using AGData.BookMySeat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGData.BookMySeat.Domain.Interfaces
{
    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetAllSeatsAsync();
        Task<Seat> GetSeatByIdAsync(Guid seatId);
        Task<Guid> AddSeatAsync(Seat seat);
        Task<Guid> UpdateSeatAsync(Guid seatId, string? updatedSeatName = null);
        Task<Guid> DeleteSeatAsync(Guid seatId);
    }
}
