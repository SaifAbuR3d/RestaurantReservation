using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Models;
public class ReservationWithOrdersDto
{
    public int ReservationId { get; set; }
    public int CustomerId { get; set; }
    public int RestaurantId { get; set; }
    public int TableId { get; set; }
    public DateTime ReservationDate { get; set; }
    public int PartySize { get; set; }
    public List<Order> Orders { get; set; }
}



