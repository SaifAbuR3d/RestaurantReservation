﻿namespace RestaurantReservation.Api.Models
{
    public class CustomerForCreationDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } =string.Empty; 
    }
}