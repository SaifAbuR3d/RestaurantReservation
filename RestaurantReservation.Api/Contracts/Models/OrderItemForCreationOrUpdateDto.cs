namespace RestaurantReservation.Api.Contracts.Models;

/// <summary>
/// Data transfer object for creating or updating an order item.
/// </summary>
public class OrderItemForCreationOrUpdateDto
{
    /// <summary>
    /// The ID of the menu item associated with the order item.
    /// </summary>
    public int MenuItemId { get; set; }

    /// <summary>
    /// The quantity of the menu item in the order.
    /// </summary>
    public int Quantity { get; set; }
}
