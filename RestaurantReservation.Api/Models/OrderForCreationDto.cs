namespace RestaurantReservation.Api.Models;

public class OrderForCreationDto
{
    // reservationId from URL
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }
}
