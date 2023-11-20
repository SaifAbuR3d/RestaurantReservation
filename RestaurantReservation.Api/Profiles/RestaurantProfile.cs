using RestaurantReservation.Api.Models;
using RestaurantReservation.Domain.Entities;
using AutoMapper; 
namespace RestaurantReservation.Api.Profiles;

public class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {
        CreateMap<Restaurant, Models.RestaurantDto>();
        CreateMap<Restaurant, Models.RestaurantWithEmployeesDto>();
        CreateMap<Restaurant, Models.RestaurantWithMenuItemsDto>();
        CreateMap<Models.RestaurantIsolatedDto, Restaurant>();
        CreateMap<Restaurant, Models.RestaurantIsolatedDto>();

    }
}
