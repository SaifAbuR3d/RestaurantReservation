namespace RestaurantReservation.Api.Contracts.Models;

public class OrderItemForCreationOrUpdateDto
{
    public int MenuItemId { get; set; }
    public int Quantity { get; set; }
}
