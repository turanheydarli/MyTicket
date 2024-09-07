using MyTicket.Data.Models;

namespace MyTicket.UI.Areas.Admin.Models;

public class MovieViewModel
{
    public Movie Movie { get; set; }
    public IFormFile ThumbnailFile { get; set; }
}