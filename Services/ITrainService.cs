using TrainBookingApp.Models;

namespace TrainBookingApp.Services;

/// <summary>
/// Interface for train-related operations
/// </summary>
public interface ITrainService
{
    /// <summary>
    /// Searches for trains based on criteria
    /// </summary>
    Task<List<Schedule>> SearchTrainsAsync(int originId, int destinationId, DateTime travelDate);
    
    /// <summary>
    /// Gets a schedule by ID with related data
    /// </summary>
    Task<Schedule?> GetScheduleByIdAsync(int scheduleId);
    
    /// <summary>
    /// Gets available seats for a schedule
    /// </summary>
    Task<List<Seat>> GetAvailableSeatsAsync(int scheduleId, int count);
}
