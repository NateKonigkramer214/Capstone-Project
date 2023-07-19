using Microsoft.AspNetCore.Identity;

namespace Capstone.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public Viewing Viewing { get; set; }
        public IdentityUser User { get; set; }
        public string Email { get; set; }
        public List<Seat> Seats { get; set; }
    }

    public class Seat
    {
        public int Id { get; set; }
        public int SeatRow { get; set; }
        public int SeatCol { get; set; }
    }
}
