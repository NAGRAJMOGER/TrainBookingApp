using Microsoft.AspNetCore.Identity;

namespace TrainBookingApp.Models;

/// <summary>
/// Represents an application user with Identity integration
/// </summary>
public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
