using AutoMapper;
using RestaurantReservation.Api.Contracts.Models;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>();
        CreateMap<OrderForCreationDto, Order>(); 
        CreateMap<OrderForUpdateDto, Order>();
        CreateMap<Order,OrderForUpdateDto>();
        CreateMap<Order, OrderWithMenuItemsDto>()
            .ForMember(dest => dest.MenuItems, opt => opt.MapFrom(src => src.OrderItems.Select(oi => oi.MenuItem)));
    }
}
