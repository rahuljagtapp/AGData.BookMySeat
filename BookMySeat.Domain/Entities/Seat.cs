using System;

namespace AGData.BookMySeat.Domain.Entities
{
    public class Seat
    {
        public Guid SeatId { get; private set; }
        public string SeatName { get; private set; }

        public Seat() { }

        public Seat(string seatName)
        {
           
            SeatName = seatName;
        }

        public void UpdateSeatName(string newName)
        {
            if (!string.IsNullOrWhiteSpace(newName))
            {
                SeatName = newName;
            }
        }


    }
}
