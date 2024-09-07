namespace MyTicket.Data.Models;

public  class Review : BaseEntity
{
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int Rating { get; set; } // Rating between 1 and 5
    public string Comment { get; set; }
}