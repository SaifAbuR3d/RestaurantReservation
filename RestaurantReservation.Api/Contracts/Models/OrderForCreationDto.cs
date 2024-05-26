namespace RestaurantReservation.Api.Contracts.Models;

/// <summary>
/// Data transfer object for creating a new order.
/// </summary>
public class OrderForCreationDto
{
    /// <summary>
    /// The ID of the employee placing the order.
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    /// The date of the order.
    /// </summary>
    public DateTime OrderDate { get; set; }
}
