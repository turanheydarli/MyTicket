using Microsoft.AspNetCore.Mvc;

namespace MyTicket.UI.Areas.Admin.ViewComponents;

public class AdminSidebarViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}