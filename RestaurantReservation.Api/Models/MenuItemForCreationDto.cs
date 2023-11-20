namespace RestaurantReservation.Api.Models;

public class MenuItemForCreationDto
{
    // restaurantId from the url
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
