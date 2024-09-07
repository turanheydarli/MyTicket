using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTicket.Data.Models;
using MyTicket.Data.Persistence;
using MyTicket.Data.Persistence.Repositories;
using MyTicket.UI.Models;

public class MovieController : Controller
{
    private readonly IRepository<Movie, AppDbContext> _repository;

    public MovieController(IRepository<Movie, AppDbContext> repository)
    {
        _repository = repository;
    }

    public IActionResult Details(int id)
    {
        var movie = _repository.Get(
            i => i.Id == id,
            include: m => m.Include(i => i.Showtimes)
                .ThenInclude(s => s.Tickets)  
                .Include(i => i.Showtimes)
                .ThenInclude(s => s.CinemaHall) 
                .ThenInclude(c => c.Seats)); 

        if (movie == null)
        {
            return NotFound();
        }

        var model = new MovieDetailsViewModel
        {
            Id = movie.Id,
            Title = movie.Title,
            Director = movie.Director,
            Genre = movie.Genre,
            Duration = movie.Duration,
            ReleaseDate = movie.ReleaseDate,
            ThumbnailUrl = movie.ThumbnailUrl,
            Showtimes = movie.Showtimes.Select(st => new ShowtimeDetailsViewModel
            {
                Id = st.Id,
                StartTime = st.StartTime,
                CinemaHall = st.CinemaHall.Name,
                AvailableSeats = st.CinemaHall.Seats.Where(seat => !st.Tickets.Any(t => t.SeatId == seat.Id)).ToList()
            }).ToList()
        };

        return View(model);
    }
}