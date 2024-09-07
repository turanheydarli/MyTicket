using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTicket.Data.Models;
using MyTicket.Data.Persistence;
using MyTicket.Data.Persistence.Repositories;
using MyTicket.UI.Areas.Admin.Models;

namespace MyTicket.UI.Areas.Admin.Controllers;

[Area("Admin")]
public class PaymentController : Controller
{
    private readonly IRepository<Payment, AppDbContext> _paymentRepository;
    private readonly IRepository<Ticket, AppDbContext> _ticketRepository;

    public PaymentController(
        IRepository<Payment, AppDbContext> paymentRepository,
        IRepository<Ticket, AppDbContext> ticketRepository)
    {
        _paymentRepository = paymentRepository;
        _ticketRepository = ticketRepository;
    }

    public IActionResult Index()
    {
        var payments = _paymentRepository.GetList(include: query => query
            .Include(p => p.Ticket)
            .ThenInclude(p => p.Seat)
            .Include(p => p.Ticket)
            .ThenInclude(t => t.Showtime)
            .ThenInclude(s => s.Movie)
            .Include(p => p.Ticket.Customer));


        return View(payments);
    }

    public IActionResult Create()
    {
        var viewModel = new PaymentViewModel
        {
            Payment = new Payment(),
            Tickets = _ticketRepository.GetList(include: c => c
                .Include(c => c.Customer)
                .Include(c => c.Seat)
                .Include(c => c.Showtime)
                .ThenInclude(c => c.Movie))
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Create(PaymentViewModel model)
    {
        _paymentRepository.Add(model.Payment);
        return RedirectToAction("Index");
    }

    public IActionResult Update(int id)
    {
        var payment = _paymentRepository.Get(
            p => p.Id == id,
            include: query => query
                .Include(p => p.Ticket)
                .ThenInclude(t => t.Showtime)
                .ThenInclude(s => s.Movie)
                .Include(p => p.Ticket.Customer));

        if (payment == null)
        {
            return NotFound();
        }

        var viewModel = new PaymentViewModel
        {
            Payment = payment,
            Tickets = _ticketRepository.GetList(include: c => c
                .Include(c => c.Customer)
                .Include(c => c.Seat)
                .Include(c => c.Showtime)
                .ThenInclude(c => c.Movie))
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Update(PaymentViewModel model)
    {
        if (ModelState.IsValid)
        {
            _paymentRepository.Update(model.Payment);
            return RedirectToAction("Index");
        }

        model.Tickets = _ticketRepository.GetList(include: c => c
            .Include(c => c.Customer)
            .Include(c => c.Seat)
            .Include(c => c.Showtime)
            .ThenInclude(c => c.Movie));
        
        return View(model);
    }

    public IActionResult Delete(int id)
    {
        var payment = _paymentRepository.Get(
            p => p.Id == id,
            include: query => query
                .Include(p => p.Ticket)
                .ThenInclude(t => t.Showtime)
                .ThenInclude(s => s.Movie)
                .Include(p => p.Ticket.Customer));

        if (payment == null)
        {
            return NotFound();
        }

        return View(new PaymentViewModel { Payment = payment });
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var payment = _paymentRepository.Get(p => p.Id == id);


        _paymentRepository.Delete(payment);
        return RedirectToAction("Index");
    }
}