using Microsoft.EntityFrameworkCore;
using TrainBookingApp.Data;
using TrainBookingApp.Models;

namespace TrainBookingApp.Services;

/// <summary>
/// Service for train-related operations
/// </summary>
public class TrainService : ITrainService
{
    private readonly ApplicationDbContext _context;

    public TrainService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Schedule>> SearchTrainsAsync(int originId, int destinationId, DateTime travelDate)
    {
        var schedules = await _context.Schedules
            .Include(s => s.Train)
            .Include(s => s.OriginStation)
            .Include(s => s.DestinationStation)
            .Include(s => s.Seats)
            .Where(s => s.OriginStationId == originId && s.DestinationStationId == destinationId)
            .ToListAsync();
        
        return schedules.OrderBy(s => s.DepartureTime).ToList();
    }

    public async Task<Schedule?> GetScheduleByIdAsync(int scheduleId)
    {
        return await _context.Schedules
            .Include(s => s.Train)
            .Include(s => s.OriginStation)
            .Include(s => s.DestinationStation)
            .Include(s => s.Seats)
            .FirstOrDefaultAsync(s => s.Id == scheduleId);
    }

    public async Task<List<Seat>> GetAvailableSeatsAsync(int scheduleId, int count)
    {
        return await _context.Seats
            .Where(s => s.ScheduleId == scheduleId && !s.IsBooked)
            .Take(count)
            .ToListAsync();
    }
}
