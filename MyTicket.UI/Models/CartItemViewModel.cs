namespace MyTicket.UI.Models;

public class CartItemViewModel
{
    public int ShowtimeId { get; set; }
    public int SeatId { get; set; }
    public string MovieTitle { get; set; }
    public string CinemaHallName { get; set; }
    public DateTime Showtime { get; set; }
    public string SeatInfo { get; set; } // E.g., Row and Seat Number
    public decimal Price { get; set; }
}