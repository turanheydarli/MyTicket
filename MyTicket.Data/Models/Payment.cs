using MyTicket.Data.Enums;

namespace MyTicket.Data.Models;

public class Payment : BaseEntity
{
    public int TicketId { get; set; }
    public Ticket Ticket { get; set; }
    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; }
    public PaymentType PaymentType { get; set; }
}