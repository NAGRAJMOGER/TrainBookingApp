using Microsoft.EntityFrameworkCore;
using TrainBookingApp.Data;
using TrainBookingApp.Models;

namespace TrainBookingApp.Services;

/// <summary>
/// Service for station-related operations
/// </summary>
public class StationService : IStationService
{
    private readonly ApplicationDbContext _context;

    public StationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Station>> GetAllStationsAsync()
    {
        return await _context.Stations.OrderBy(s => s.Name).ToListAsync();
    }

    public async Task<Station?> GetStationByIdAsync(int id)
    {
        return await _context.Stations.FindAsync(id);
    }
}
