using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrainBookingApp.Models;

namespace TrainBookingApp.Data;

/// <summary>
/// Database context for the application
/// </summary>
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Station> Stations { get; set; } = null!;
    public DbSet<Train> Trains { get; set; } = null!;
    public DbSet<Schedule> Schedules { get; set; } = null!;
    public DbSet<Seat> Seats { get; set; } = null!;
    public DbSet<Booking> Bookings { get; set; } = null!;
    public DbSet<Passenger> Passengers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure relationships
        modelBuilder.Entity<Schedule>()
            .HasOne(s => s.Train)
            .WithMany(t => t.Schedules)
            .HasForeignKey(s => s.TrainId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Schedule>()
            .HasOne(s => s.OriginStation)
            .WithMany()
            .HasForeignKey(s => s.OriginStationId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Schedule>()
            .HasOne(s => s.DestinationStation)
            .WithMany()
            .HasForeignKey(s => s.DestinationStationId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Seat>()
            .HasOne(s => s.Schedule)
            .WithMany(sch => sch.Seats)
            .HasForeignKey(s => s.ScheduleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Schedule)
            .WithMany()
            .HasForeignKey(b => b.ScheduleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Passenger>()
            .HasOne(p => p.Booking)
            .WithMany(b => b.Passengers)
            .HasForeignKey(p => p.BookingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
