using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTicket.Data.Models;
using MyTicket.Data.Persistence;
using MyTicket.Data.Persistence.Repositories;
using MyTicket.UI.Areas.Admin.Models;

namespace MyTicket.UI.Areas.Admin.Controllers;

[Area("Admin")]
public class TicketController : Controller
{
    private readonly IRepository<Ticket, AppDbContext> _ticketRepository;
    private readonly IRepository<Showtime, AppDbContext> _showtimeRepository;
    private readonly IRepository<Customer, AppDbContext> _customerRepository;

    public TicketController(
        IRepository<Ticket, AppDbContext> ticketRepository,
        IRepository<Showtime, AppDbContext> showtimeRepository,
        IRepository<Customer, AppDbContext> customerRepository)
    {
        _ticketRepository = ticketRepository;
        _showtimeRepository = showtimeRepository;
        _customerRepository = customerRepository;
    }

    public IActionResult Index()
    {
        var tickets = _ticketRepository.GetList(include: query => query
            .Include(t => t.Showtime)
            .ThenInclude(t => t.CinemaHall)
            .Include(t => t.Showtime)
            .ThenInclude(s => s.Movie)
            .Include(t => t.Seat)
            .Include(t => t.Customer));

        return View(tickets);
    }

    [HttpGet]
    public IActionResult GetSeatsByShowtime(int showtimeId)
    {
        var showtime = _showtimeRepository.Get(s => s.Id == showtimeId,
            include: q => q.Include(s => s.CinemaHall)
                .ThenInclude(ch => ch.Seats));

        if (showtime == null || showtime.CinemaHall == null)
        {
            return NotFound();
        }

        var seats = showtime.CinemaHall.Seats.Select(s => new
        {
            s.Id,
            s.SeatNumber,
            s.Row,
            s.Column
        });

        return Json(seats);
    }

    public IActionResult Create()
    {
        var viewModel = new TicketViewModel
        {
            Ticket = new Ticket(),
            Showtimes = _showtimeRepository.GetList(),
            Customers = _customerRepository.GetList(),
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Create(TicketViewModel model)
    {
        model.Ticket.Seat = null;

        _ticketRepository.Add(model.Ticket);
        return RedirectToAction("Index");
    }

    public IActionResult Update(int id)
    {
        var ticket = _ticketRepository.Get(
            t => t.Id == id,
            include: query => query
                .Include(t => t.Showtime)
                .Include(t => t.Customer));

        if (ticket == null)
        {
            return NotFound();
        }

        var viewModel = new TicketViewModel
        {
            Ticket = ticket,
            Showtimes = _showtimeRepository.GetList(),
            Customers = _customerRepository.GetList()
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Update(TicketViewModel model)
    {
        _ticketRepository.Update(model.Ticket);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var ticket = _ticketRepository.Get(
            t => t.Id == id,
            include: query => query
                .Include(t => t.Showtime)
                .Include(t => t.Customer));

        return View(new TicketViewModel { Ticket = ticket });
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var ticket = _ticketRepository.Get(t => t.Id == id);
        if (ticket == null)
        {
            return NotFound();
        }

        _ticketRepository.Delete(ticket);
        return RedirectToAction("Index");
    }
}