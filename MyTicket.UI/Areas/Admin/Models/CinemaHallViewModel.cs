using MyTicket.Data.Models;

namespace MyTicket.UI.Areas.Admin.Models;

public class CinemaHallViewModel
{
    public CinemaHall CinemaHall { get; set; } 
    public IList<Seat> Seats { get; set; } = new List<Seat>();
}