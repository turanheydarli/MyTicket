using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MyTicket.Data.Models;
using MyTicket.Data.Persistence.Configurations;

namespace MyTicket.Data.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<CinemaHall> CinemaHalls { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Showtime> Showtimes { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(AppDbContext)) ??
                                                     Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}