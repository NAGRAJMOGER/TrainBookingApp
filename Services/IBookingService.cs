using TrainBookingApp.Models;

namespace TrainBookingApp.Services;

/// <summary>
/// Interface for booking-related operations
/// </summary>
public interface IBookingService
{
    /// <summary>
    /// Creates a new booking
    /// </summary>
    Task<Booking> CreateBookingAsync(Booking booking, List<int> seatIds);
    
    /// <summary>
    /// Gets bookings for a user
    /// </summary>
    Task<List<Booking>> GetUserBookingsAsync(string userId);
    
    /// <summary>
    /// Gets a booking by ID
    /// </summary>
    Task<Booking?> GetBookingByIdAsync(int bookingId);
    
    /// <summary>
    /// Gets a booking by PNR
    /// </summary>
    Task<Booking?> GetBookingByPNRAsync(string pnr);
    
    /// <summary>
    /// Cancels a booking
    /// </summary>
    Task<bool> CancelBookingAsync(int bookingId);
    
    /// <summary>
    /// Generates a unique PNR
    /// </summary>
    string GeneratePNR();
}
