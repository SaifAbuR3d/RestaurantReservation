namespace RestaurantReservation.Api.Models
{
    public class TableDto
    {
        public int TableId { get; set; }
        public int RestaurantID { get; set; }
        public int Capacity { get; set; }
    }
}
