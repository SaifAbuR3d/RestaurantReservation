﻿namespace RestaurantReservation.Api.Models;

public class RestaurantDto
{
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string OpenningHours { get; set; }
}