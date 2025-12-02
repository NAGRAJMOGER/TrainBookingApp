using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainBookingApp.Models;

/// <summary>
/// Represents a booking made by a user
/// </summary>
public class Booking
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string PNR { get; set; } = string.Empty;
    
    public string UserId { get; set; } = string.Empty;
    
    [ForeignKey(nameof(UserId))]
    public virtual ApplicationUser User { get; set; } = null!;
    
    public int ScheduleId { get; set; }
    
    [ForeignKey(nameof(ScheduleId))]
    public virtual Schedule Schedule { get; set; } = null!;
    
    public DateTime BookingDate { get; set; } = DateTime.UtcNow;
    
    public DateTime TravelDate { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }
    
    public BookingStatus Status { get; set; } = BookingStatus.Confirmed;
    
    public virtual ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();
    
    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
}
