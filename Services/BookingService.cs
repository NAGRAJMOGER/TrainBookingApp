using Microsoft.EntityFrameworkCore;
using TrainBookingApp.Data;
using TrainBookingApp.Models;

namespace TrainBookingApp.Services;

/// <summary>
/// Service for booking-related operations
/// </summary>
public class BookingService : IBookingService
{
    private readonly ApplicationDbContext _context;

    public BookingService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Booking> CreateBookingAsync(Booking booking, List<int> seatIds)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            // Generate PNR
            booking.PNR = GeneratePNR();
            booking.BookingDate = DateTime.UtcNow;
            booking.Status = BookingStatus.Confirmed;

            // Add booking
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            // Update seats
            var seats = await _context.Seats
                .Where(s => seatIds.Contains(s.Id) && !s.IsBooked)
                .ToListAsync();

            if (seats.Count != seatIds.Count)
            {
                throw new InvalidOperationException("Some seats are no longer available");
            }

            foreach (var seat in seats)
            {
                seat.IsBooked = true;
                seat.BookingId = booking.Id;
            }

            // Update passenger seat numbers
            for (int i = 0; i < booking.Passengers.Count && i < seats.Count; i++)
            {
                booking.Passengers.ElementAt(i).SeatNumber = seats[i].SeatNumber;
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return booking;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<List<Booking>> GetUserBookingsAsync(string userId)
    {
        return await _context.Bookings
            .Include(b => b.Schedule)
                .ThenInclude(s => s.Train)
            .Include(b => b.Schedule)
                .ThenInclude(s => s.OriginStation)
            .Include(b => b.Schedule)
                .ThenInclude(s => s.DestinationStation)
            .Include(b => b.Passengers)
            .Include(b => b.Seats)
            .Where(b => b.UserId == userId)
            .OrderByDescending(b => b.BookingDate)
            .ToListAsync();
    }

    public async Task<Booking?> GetBookingByIdAsync(int bookingId)
    {
        return await _context.Bookings
            .Include(b => b.Schedule)
                .ThenInclude(s => s.Train)
            .Include(b => b.Schedule)
                .ThenInclude(s => s.OriginStation)
            .Include(b => b.Schedule)
                .ThenInclude(s => s.DestinationStation)
            .Include(b => b.Passengers)
            .Include(b => b.Seats)
            .FirstOrDefaultAsync(b => b.Id == bookingId);
    }

    public async Task<Booking?> GetBookingByPNRAsync(string pnr)
    {
        return await _context.Bookings
            .Include(b => b.Schedule)
                .ThenInclude(s => s.Train)
            .Include(b => b.Schedule)
                .ThenInclude(s => s.OriginStation)
            .Include(b => b.Schedule)
                .ThenInclude(s => s.DestinationStation)
            .Include(b => b.Passengers)
            .Include(b => b.Seats)
            .FirstOrDefaultAsync(b => b.PNR == pnr);
    }

    public async Task<bool> CancelBookingAsync(int bookingId)
    {
        var booking = await _context.Bookings
            .Include(b => b.Seats)
            .FirstOrDefaultAsync(b => b.Id == bookingId);

        if (booking == null || booking.Status == BookingStatus.Cancelled)
        {
            return false;
        }

        booking.Status = BookingStatus.Cancelled;

        // Release seats
        foreach (var seat in booking.Seats)
        {
            seat.IsBooked = false;
            seat.BookingId = null;
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public string GeneratePNR()
    {
        // Generate a 10-digit PNR
        var random = new Random();
        return random.Next(1000000000, int.MaxValue).ToString();
    }
}
