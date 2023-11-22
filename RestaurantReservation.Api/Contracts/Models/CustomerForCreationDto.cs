namespace RestaurantReservation.Api.Contracts;

/// <summary>
/// Data transfer object for creating a customer.
/// </summary>
public class CustomerForCreationDto
{
    /// <summary>
    /// The first name of the customer.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// The last name of the customer.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// The email address of the customer.
    /// </summary>
    public string Email { get; set; } = string.Empty;
}
