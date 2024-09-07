using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTicket.Data.Models;
using MyTicket.Data.Persistence;
using MyTicket.Data.Persistence.Repositories;
using MyTicket.UI.Models;

namespace MyTicket.UI.Controllers;

public class HomeController : Controller
{
    private readonly IRepository<Movie, AppDbContext> _repository;

    public HomeController(IRepository<Movie, AppDbContext> repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        var lastAddedMovies = _repository
            .GetList(include: i => i.Include(m => m.Showtimes)
                .ThenInclude(m => m.CinemaHall))
            .OrderByDescending(m => m.ReleaseDate)
            .Take(5)
            .Select(m => new MovieViewModel
            {
                Id = m.Id,
                ThumbnailUrl = m.ThumbnailUrl,
                Director = m.Director,
                Duration = m.Duration,
                Genre = m.Genre,
                Title = m.Title,
                ReleaseDate = m.ReleaseDate,
                Showtimes = m.Showtimes.Select(st => new ShowtimeViewModel
                {
                    Id = st.Id,
                    StartTime = st.StartTime,
                    CinemaHall = new CinemaHallViewModel
                    {
                        Name = st.CinemaHall.Name,
                        Location = st.CinemaHall.Location
                    }
                }).ToList()
            })
            .ToList();

        var trendingMovies = _repository.GetList(include: i => i.Include(m => m.Reviews)
                .Include(m => m.Showtimes).ThenInclude(n => n.CinemaHall))
            .OrderByDescending(m => m.Reviews.Count)
            .Take(5)
            .Select(m => new MovieViewModel
            {
                Id = m.Id,
                ThumbnailUrl = m.ThumbnailUrl,
                Director = m.Director,
                Duration = m.Duration,
                Genre = m.Genre,
                Title = m.Title,
                ReleaseDate = m.ReleaseDate,
                Showtimes = m.Showtimes.Select(st => new ShowtimeViewModel
                {
                    Id = st.Id,
                    StartTime = st.StartTime,
                    CinemaHall = new CinemaHallViewModel
                    {
                        Name = st.CinemaHall.Name,
                        Location = st.CinemaHall.Location
                    }
                }).ToList()
            })
            .ToList();

        var model = new HomePageViewModel
        {
            LastAddedMovies = lastAddedMovies,
            TrendingMovies = trendingMovies
        };

        return View(model);
    }
}