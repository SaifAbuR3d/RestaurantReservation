namespace RestaurantReservation.Api.Contracts.Models;

/// <summary>
/// Data transfer object representing basic information about a restaurant, Used For Create/Update.
/// </summary>
public class RestaurantIsolatedDto
{
    /// <summary>
    /// The name of the restaurant.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The address of the restaurant.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// The phone number of the restaurant.
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// The opening hours of the restaurant.
    /// </summary>
    public string OpenningHours { get; set; }
}
