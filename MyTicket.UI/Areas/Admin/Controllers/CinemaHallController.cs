using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTicket.Data.Models;
using MyTicket.Data.Persistence;
using MyTicket.Data.Persistence.Repositories;
using MyTicket.UI.Areas.Admin.Models;

namespace MyTicket.UI.Areas.Admin.Controllers;

[Area("Admin")]
public class CinemaHallController : Controller
{
    private readonly IRepository<CinemaHall, AppDbContext> _repository;
    private readonly IRepository<Seat, AppDbContext> _seatRepository;

    public CinemaHallController(IRepository<CinemaHall?, AppDbContext> repository,
        IRepository<Seat, AppDbContext> seatRepository)
    {
        _repository = repository;
        _seatRepository = seatRepository;
    }

    public IActionResult Index()
    {
        var halls = _repository.GetList();

        return View(halls);
    }

    public IActionResult Create()
    {
        return View(new CinemaHallViewModel());
    }

    [HttpPost]
    public IActionResult Create(CinemaHallViewModel model)
    {
        var addedHall = _repository.Add(model.CinemaHall);

        foreach (var seat in model.Seats)
        {
            seat.CinemaHallId = addedHall.Id;

            _seatRepository.Add(seat);
        }


        return RedirectToAction("Index");
    }

    public IActionResult Update(int id)
    {
        CinemaHall hall = _repository.Get(e => e.Id == id);

        CinemaHallViewModel viewModel = new()
        {
            CinemaHall = hall,
            Seats = _seatRepository.GetList(s => s.CinemaHallId == id)
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Update(CinemaHallViewModel model)
    {
        foreach (var seat in model.Seats)
        {
            if (seat.Id == 0)
            {
                seat.CinemaHallId = model.CinemaHall.Id;

                _seatRepository.Add(seat);
            }
            else
            {
                _seatRepository.Update(seat);
            }
        }

        _repository.Update(model.CinemaHall);

        return View("Update");
    }


    public IActionResult Delete(int id)
    {
        CinemaHall? hall = _repository.Get(e => e.Id == id);

        CinemaHallViewModel viewModel = new()
        {
            CinemaHall = hall
        };

        return View(viewModel);
    }


    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        CinemaHall? hall = _repository.Get(e => e.Id == id);

        _repository.Delete(hall);

        return RedirectToAction("Index");
    }
}