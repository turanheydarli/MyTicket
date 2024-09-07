namespace MyTicket.Data.Models;

public class CinemaHall : BaseEntity
{
    public string Name { get; set; }
    public string Location { get; set; }
    public int Capacity { get; set; }
    public ICollection<Seat> Seats { get; set; }
    public ICollection<Showtime> Showtimes { get; set; }
}