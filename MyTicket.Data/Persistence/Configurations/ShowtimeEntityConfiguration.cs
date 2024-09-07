using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTicket.Data.Models;

namespace MyTicket.Data.Persistence.Configurations;

public class ShowtimeEntityConfiguration : IEntityTypeConfiguration<Showtime>
{
    public void Configure(EntityTypeBuilder<Showtime> builder)
    {
        builder.HasOne(s => s.CinemaHall)
            .WithMany(ch => ch.Showtimes)
            .HasForeignKey(s => s.CinemaHallId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}