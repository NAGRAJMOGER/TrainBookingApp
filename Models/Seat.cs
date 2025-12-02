using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainBookingApp.Models;

/// <summary>
/// Represents a seat in a train schedule
/// </summary>
public class Seat
{
    [Key]
    public int Id { get; set; }
    
    public int ScheduleId { get; set; }
    
    [ForeignKey(nameof(ScheduleId))]
    public virtual Schedule Schedule { get; set; } = null!;
    
    [Required]
    [MaxLength(10)]
    public string SeatNumber { get; set; } = string.Empty;
    
    public bool IsBooked { get; set; }
    
    public int? BookingId { get; set; }
    
    [ForeignKey(nameof(BookingId))]
    public virtual Booking? Booking { get; set; }
}
