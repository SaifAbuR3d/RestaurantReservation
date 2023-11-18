namespace RestaurantReservation.Domain.Models;

public class Order
{
    public int OrderID { get; set; }
    public int ReservationID { get; set; }
    public int EmployeeID { get; set; }
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
