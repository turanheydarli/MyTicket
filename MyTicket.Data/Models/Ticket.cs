namespace MyTicket.Data.Models;

public class Ticket : BaseEntity
{
    public int ShowtimeId { get; set; }
    public Showtime Showtime { get; set; }
    
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public int SeatId { get; set; }
    public Seat Seat { get; set; }
    public DateTime PurchaseDate { get; set; } 
    public Payment Payment { get; set; }

}
