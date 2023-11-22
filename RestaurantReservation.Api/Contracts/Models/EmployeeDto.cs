namespace RestaurantReservation.Api.Contracts.Models;

public class EmployeeDto
{
    public int EmployeeId { get; set; }
    public int RestaurantId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
}
