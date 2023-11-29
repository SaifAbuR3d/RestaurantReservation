namespace RestaurantReservation.Api.Contracts.Models;

/// <summary>
/// Data transfer object for updating customer information.
/// </summary>
public class CustomerForUpdateDto
{
    /// <summary>
    /// Updated first name of the customer.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Updated last name of the customer.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Updated email address of the customer.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Updated phone number of the customer.
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;
}
