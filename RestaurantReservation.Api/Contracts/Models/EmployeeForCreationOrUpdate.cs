namespace RestaurantReservation.Api.Contracts.Models;

public class EmployeeForCreationOrUpdate
{
    public int RestaurantId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
}
