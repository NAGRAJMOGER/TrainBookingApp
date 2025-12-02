using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainBookingApp.Models;

/// <summary>
/// Represents a passenger in a booking
/// </summary>
public class Passenger
{
    [Key]
    public int Id { get; set; }
    
    public int BookingId { get; set; }
    
    [ForeignKey(nameof(BookingId))]
    public virtual Booking Booking { get; set; } = null!;
    
    [Required]
    [MaxLength(100)]
    public string FullName { get; set; } = string.Empty;
    
    [Required]
    public int Age { get; set; }
    
    [Required]
    [MaxLength(10)]
    public string Gender { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string IdProofType { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string IdProofNumber { get; set; } = string.Empty;
    
    [MaxLength(15)]
    public string? ContactNumber { get; set; }
    
    [MaxLength(100)]
    public string? Email { get; set; }
    
    [MaxLength(10)]
    public string? SeatNumber { get; set; }
}
