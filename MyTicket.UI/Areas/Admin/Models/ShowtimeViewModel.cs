using MyTicket.Data.Models;

namespace MyTicket.UI.Areas.Admin.Models;

public class ShowtimeViewModel
{
    public Showtime Showtime { get; set; }
    public List<Movie> Movies { get; set; }
    public List<CinemaHall> CinemaHalls { get; set; }
}