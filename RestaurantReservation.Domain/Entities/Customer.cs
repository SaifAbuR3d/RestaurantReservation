namespace RestaurantReservation.Domain.Entities;

public class Customer
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; } = string.Empty; 
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty; 
    public string? PhoneNumber { get; set; }
    public List<Reservation> Reservations { get; set; }

}
