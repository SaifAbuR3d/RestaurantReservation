using AutoMapper;
using RestaurantReservation.Api.Models;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderForCreationDto, Order>(); 
            CreateMap<OrderForUpdateDto, Order>();
            CreateMap<Order,OrderForUpdateDto>();
        }
    }
}
