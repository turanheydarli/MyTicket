namespace MyTicket.Data.Models;

public class Seat : BaseEntity
{
    public int SeatNumber { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
    public int CinemaHallId { get; set; }
    
    public CinemaHall CinemaHall { get; set; }
}