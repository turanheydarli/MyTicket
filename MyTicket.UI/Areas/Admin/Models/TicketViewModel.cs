using MyTicket.Data.Models;

namespace MyTicket.UI.Areas.Admin.Models;

public class TicketViewModel
{
    public Ticket Ticket { get; set; }
    public IEnumerable<Showtime> Showtimes { get; set; }
    public IEnumerable<Customer> Customers { get; set; }
    public IEnumerable<Seat> AvailableSeats { get; set; }
}