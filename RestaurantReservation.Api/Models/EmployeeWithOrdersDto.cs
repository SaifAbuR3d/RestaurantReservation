using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Models;

public class EmployeeWithOrdersDto
{
    public int EmployeeId { get; set; }
    public int RestaurantId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public List<OrderDto> Orders { get; set; }
}
