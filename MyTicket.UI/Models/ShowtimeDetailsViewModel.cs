using MyTicket.Data.Models;

namespace MyTicket.UI.Models;

public class ShowtimeDetailsViewModel
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public string CinemaHall { get; set; }
    public List<Seat> AvailableSeats { get; set; }
}