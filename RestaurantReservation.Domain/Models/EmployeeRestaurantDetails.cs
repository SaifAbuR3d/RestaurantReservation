namespace RestaurantReservation.Domain.Models;

public record EmployeeRestaurantDetails(int EmployeeId,
    string FirstName,
    string LastName,
    string Position,
    int RestaurantId,
    string RestaurantName,
    string Address,
    string PhoneNumber,
    string OpenningHours);