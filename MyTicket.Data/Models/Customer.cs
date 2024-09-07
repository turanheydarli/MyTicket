namespace MyTicket.Data.Models;

public class Customer : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Ticket> Tickets { get; set; }
    public ICollection<Review> Reviews { get; set; }
}