namespace RestaurantReservation.Api.Contracts.Models;

public class OrderForUpdateDto
{
    public int ReservationId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }
}
