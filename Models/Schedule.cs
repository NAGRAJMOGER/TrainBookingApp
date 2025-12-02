using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainBookingApp.Models;

/// <summary>
/// Represents a train schedule between two stations
/// </summary>
public class Schedule
{
    [Key]
    public int Id { get; set; }
    
    public int TrainId { get; set; }
    
    [ForeignKey(nameof(TrainId))]
    public virtual Train Train { get; set; } = null!;
    
    public int OriginStationId { get; set; }
    
    [ForeignKey(nameof(OriginStationId))]
    public virtual Station OriginStation { get; set; } = null!;
    
    public int DestinationStationId { get; set; }
    
    [ForeignKey(nameof(DestinationStationId))]
    public virtual Station DestinationStation { get; set; } = null!;
    
    public TimeSpan DepartureTime { get; set; }
    
    public TimeSpan ArrivalTime { get; set; }
    
    public TimeSpan Duration { get; set; }
    
    public SeatClass SeatClass { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    
    public int TotalSeats { get; set; }
    
    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
}
