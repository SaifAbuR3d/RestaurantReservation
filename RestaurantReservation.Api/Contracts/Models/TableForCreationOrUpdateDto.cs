namespace RestaurantReservation.Api.Contracts.Models;

/// <summary>
/// Data transfer object representing the capacity information for creating or updating a table.
/// </summary>
public class TableForCreationOrUpdateDto
{
    /// <summary>
    /// The capacity of the table.
    /// </summary>
    public int Capacity { get; set; }
}
