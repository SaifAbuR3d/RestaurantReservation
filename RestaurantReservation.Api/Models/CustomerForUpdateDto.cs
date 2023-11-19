using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Models
{
    public class CustomerForUpdateDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

    }
}
