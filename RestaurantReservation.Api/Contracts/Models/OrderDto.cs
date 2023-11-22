namespace RestaurantReservation.Api.Contracts.Models;
public class OrderDto
{
    public int OrderId { get; set; }
    public int ReservationId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal? TotalAmount { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }
}
