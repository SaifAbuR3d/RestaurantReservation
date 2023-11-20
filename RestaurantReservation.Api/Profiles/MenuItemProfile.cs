using AutoMapper;
using RestaurantReservation.Api.Models;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Profiles
{
    public class MenuItemProfile : Profile
    {
        public MenuItemProfile()
        {
            CreateMap<MenuItem, MenuItemDto>();
            CreateMap<MenuItemForUpdateDto, MenuItem>();
            CreateMap<MenuItem, MenuItemForUpdateDto>();
            CreateMap<MenuItemForCreationDto, MenuItem>();
        }
    }
}
