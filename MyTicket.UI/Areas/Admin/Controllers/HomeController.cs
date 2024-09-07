using Microsoft.AspNetCore.Mvc;

namespace MyTicket.UI.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return RedirectToAction("Index", "CinemaHall");
    }
}