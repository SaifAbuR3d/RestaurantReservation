namespace RestaurantReservation.Api.Contracts.Models;

public class MenuItemDto
{
    public int MenuItemId { get; set; }
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
