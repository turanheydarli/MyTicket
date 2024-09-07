namespace MyTicket.Data.Models;

public class Movie : BaseEntity
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }
    public string Director { get; set; }
    public string ThumbnailUrl { get; set; }
    public DateTime ReleaseDate { get; set; }
    public ICollection<Showtime> Showtimes { get; set; }
    public ICollection<Review> Reviews { get; set; }
}