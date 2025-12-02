using System.ComponentModel.DataAnnotations;

namespace TrainBookingApp.Models;

/// <summary>
/// Represents a train with its basic details
/// </summary>
public class Train
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string TrainNumber { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string TrainName { get; set; } = string.Empty;
    
    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
