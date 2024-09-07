using MyTicket.Data.Models;

namespace MyTicket.UI.Areas.Admin.Models;

public class PaymentViewModel
{
    public Payment Payment { get; set; }
    public IEnumerable<Ticket> Tickets { get; set; }
}