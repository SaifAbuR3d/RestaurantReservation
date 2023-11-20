namespace RestaurantReservation.Domain.Entities;

public class Table
{
    public int TableId { get; set; }
    public int RestaurantId { get; set; }
    public int Capacity { get; set; }
    public Restaurant Restaurant { get; set; }

    //public Table(Restaurant restaurant)
    //{
    //    Restaurant = restaurant;
    //}
}
