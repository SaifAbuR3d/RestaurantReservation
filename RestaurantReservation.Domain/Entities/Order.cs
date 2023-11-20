namespace RestaurantReservation.Domain.Entities;

public class Order
{
    public int OrderId { get; set; }
    public int ReservationId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public Reservation Reservation { get; set; }
    public Employee Employee { get; set; }
    public List<OrderItem> OrderItems { get; set; }

    //public Order(ICollection<OrderItem> orderItems, Reservation reservation)
    //{
    //    OrderItems = new List<OrderItem>(orderItems);
    //    Reservation = reservation
    //    ReservationId = reservation.Id
    //    CalculateTotalAmount();
    //}

    private void CalculateTotalAmount()
    {
        TotalAmount = OrderItems.Sum(orderItem => orderItem.Quantity * orderItem.MenuItem.Price);
    }

}
