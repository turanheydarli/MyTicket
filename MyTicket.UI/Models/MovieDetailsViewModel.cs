namespace MyTicket.UI.Models;

public class MovieDetailsViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Director { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string ThumbnailUrl { get; set; }
    public List<ShowtimeDetailsViewModel> Showtimes { get; set; }
}