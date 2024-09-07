namespace MyTicket.UI.Models;

public class MovieViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; } // Duration in minutes
    public string Director { get; set; }
    public string ThumbnailUrl { get; set; }
    public DateTime ReleaseDate { get; set; }
    public List<ShowtimeViewModel> Showtimes { get; set; } // List of showtimes for the movie
}

public class ShowtimeViewModel
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public CinemaHallViewModel CinemaHall { get; set; } 
    public List<SeatViewModel> Seats { get; set; } 
}

public class CinemaHallViewModel
{
    public string Name { get; set; }
    public string Location { get; set; }
}

public class SeatViewModel
{
    public int Id { get; set; }
    public int Row { get; set; }
    public int SeatNumber { get; set; }
    public bool IsAvailable { get; set; } 
}

public class HomePageViewModel
{
    public IEnumerable<MovieViewModel> LastAddedMovies { get; set; }
    public IEnumerable<MovieViewModel> TrendingMovies { get; set; }
}