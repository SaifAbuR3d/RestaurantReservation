namespace RestaurantReservation.Api.Contracts.Models;

public class OrderForCreationDto
{
    // reservationId from URL
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }
}
