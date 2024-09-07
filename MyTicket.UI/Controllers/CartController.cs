using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTicket.Data.Enums;
using MyTicket.Data.Models;
using MyTicket.Data.Persistence;
using MyTicket.Data.Persistence.Repositories;
using MyTicket.UI.Extensions;
using MyTicket.UI.Models;

namespace MyTicket.UI.Controllers;

public class CartController : Controller
{
    private readonly IRepository<Showtime, AppDbContext> _showtimeRepository;
    private readonly IRepository<Seat, AppDbContext> _seatRepository;
    private readonly IRepository<Ticket, AppDbContext> _ticketRepository;
    private readonly IRepository<Payment, AppDbContext> _paymentRepository; // Added Payment repository

    public CartController(IRepository<Seat, AppDbContext> seatRepository,
        IRepository<Showtime, AppDbContext> showtimeRepository,
        IRepository<Ticket, AppDbContext> ticketRepository,
        IRepository<Payment, AppDbContext> paymentRepository) // Inject Payment repository
    {
        _seatRepository = seatRepository;
        _showtimeRepository = showtimeRepository;
        _ticketRepository = ticketRepository;
        _paymentRepository = paymentRepository; // Assign Payment repository
    }

    [HttpPost]
    public IActionResult AddToCart(int showtimeId, int seatId, decimal price)
    {
        var cart = HttpContext.Session.GetObjectFromJson<List<CartItemViewModel>>("Cart") ??
                   new List<CartItemViewModel>();

        var showtime = _showtimeRepository.Get(s => s.Id == showtimeId, include: i =>
            i.Include(m => m.Movie)
                .Include(i => i.CinemaHall));

        var seat = _seatRepository.Get(s => s.Id == seatId); // Corrected to seatId

        cart.Add(new CartItemViewModel
        {
            ShowtimeId = showtimeId,
            SeatId = seatId,
            MovieTitle = showtime.Movie.Title,
            CinemaHallName = showtime.CinemaHall.Name,
            Showtime = showtime.StartTime,
            SeatInfo = $"Row {seat.Row}, Seat {seat.SeatNumber}",
            Price = price
        });

        HttpContext.Session.SetObjectAsJson("Cart", cart);

        return RedirectToAction("Index", "Cart");
    }

    public IActionResult Index()
    {
        var cart = HttpContext.Session.GetObjectFromJson<List<CartItemViewModel>>("Cart") ??
                   new List<CartItemViewModel>();
        return View(cart);
    }

    // Checkout process to finalize the purchase
    [HttpPost]
    public IActionResult Checkout()
    {
        var cart = HttpContext.Session.GetObjectFromJson<List<CartItemViewModel>>("Cart");

        if (cart == null || !cart.Any())
        {
            return RedirectToAction("Index", "Home");
        }

        foreach (var item in cart)
        {
            // Create the ticket and payment logic
            var ticket = new Ticket
            {
                ShowtimeId = item.ShowtimeId,
                SeatId = item.SeatId,
                CustomerId = GetCustomerId(),
                PurchaseDate = DateTime.Now
            };
            _ticketRepository.Add(ticket);

            var payment = new Payment
            {
                TicketId = ticket.Id,
                Amount = item.Price,
                PaymentDate = DateTime.Now,
                PaymentType = PaymentType.CreditCard // Example payment type
            };
            _paymentRepository.Add(payment); // Add payment logic
        }

        // Clear the cart after successful checkout
        HttpContext.Session.Remove("Cart");

        return RedirectToAction("Confirmation");
    }

    // Confirmation page after checkout
    public IActionResult Confirmation()
    {
        return View();
    }

    private int GetCustomerId()
    {
        return 2;
    }
}
