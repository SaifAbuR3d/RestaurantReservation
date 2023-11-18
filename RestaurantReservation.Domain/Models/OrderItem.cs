namespace RestaurantReservation.Domain.Models;

public class OrderItem
{
    public int OrderItemId { get; set; }
    public int OrderID { get; set; }
    public int MenuItemID { get; set; }
    public int Quantity { get; set; }
    public Order Order { get; set; }
    public MenuItem MenuItem { get; set; }

    //public OrderItem(MenuItem menuItem, int quantity)
    //{
    //    MenuItem = menuItem;
    //    Quantity = quantity;
    //}
}
