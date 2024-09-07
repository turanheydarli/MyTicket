using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTicket.Data.Models;
using MyTicket.Data.Persistence;
using MyTicket.Data.Persistence.Repositories;
using MyTicket.UI.Areas.Admin.Models;

namespace MyTicket.UI.Areas.Admin.Controllers;

[Area("Admin")]
public class ShowtimeController : Controller
{
    private readonly IRepository<Showtime, AppDbContext> _showtimeRepository;
    private readonly IRepository<Movie, AppDbContext> _movieRepository;
    private readonly IRepository<CinemaHall, AppDbContext> _cinemaHallRepository;

    public ShowtimeController(
        IRepository<Showtime, AppDbContext> showtimeRepository,
        IRepository<Movie, AppDbContext> movieRepository,
        IRepository<CinemaHall, AppDbContext> cinemaHallRepository)
    {
        _showtimeRepository = showtimeRepository;
        _movieRepository = movieRepository;
        _cinemaHallRepository = cinemaHallRepository;
    }

    public IActionResult Index()
    {
        var showtimes = _showtimeRepository.GetList(include: i =>
        {
            return i.Include(s => s.CinemaHall).Include(s => s.Movie);
        });

        return View(showtimes);
    }

    public IActionResult Create()
    {
        var model = new ShowtimeViewModel
        {
            Movies = _movieRepository.GetList().ToList(),
            CinemaHalls = _cinemaHallRepository.GetList().ToList()
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Create(ShowtimeViewModel model)
    {
        _showtimeRepository.Add(model.Showtime);
        return RedirectToAction("Index");
    }

    public IActionResult Update(int id)
    {
        var showtime = _showtimeRepository.Get(s => s.Id == id);

        var model = new ShowtimeViewModel
        {
            Showtime = showtime,
            Movies = _movieRepository.GetList().ToList(),
            CinemaHalls = _cinemaHallRepository.GetList().ToList()
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Update(ShowtimeViewModel model)
    {
        _showtimeRepository.Update(model.Showtime);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var showtime = _showtimeRepository.Get(s => s.Id == id);
        if (showtime == null)
        {
            return NotFound();
        }

        return View(showtime);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var showtime = _showtimeRepository.Get(s => s.Id == id);

        _showtimeRepository.Delete(showtime);
        return RedirectToAction("Index");
    }
}