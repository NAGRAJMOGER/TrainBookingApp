using System.ComponentModel.DataAnnotations;

namespace TrainBookingApp.Models;

/// <summary>
/// Represents a railway station
/// </summary>
public class Station
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(10)]
    public string Code { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string City { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string State { get; set; } = string.Empty;
}
