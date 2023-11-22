using AutoMapper;
using RestaurantReservation.Api.Models;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Profiles;

public class OrderItemProfile:Profile
{
    public OrderItemProfile()
    {
        CreateMap<OrderItem, OrderItemDto>();
        CreateMap<OrderItemForCreationOrUpdateDto, OrderItem>();
        CreateMap<OrderItem, OrderItemForCreationOrUpdateDto>(); 
    }
}
