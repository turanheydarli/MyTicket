using Microsoft.AspNetCore.Mvc;

namespace MyTicket.UI.Areas.Admin.ViewComponents;

public class AdminTopBarViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}