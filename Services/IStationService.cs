using TrainBookingApp.Models;

namespace TrainBookingApp.Services;

/// <summary>
/// Interface for station-related operations
/// </summary>
public interface IStationService
{
    /// <summary>
    /// Gets all stations
    /// </summary>
    Task<List<Station>> GetAllStationsAsync();
    
    /// <summary>
    /// Gets a station by ID
    /// </summary>
    Task<Station?> GetStationByIdAsync(int id);
}
