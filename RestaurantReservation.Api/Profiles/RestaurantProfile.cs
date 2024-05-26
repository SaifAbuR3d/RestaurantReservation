using RestaurantReservation.Domain.Entities;
using AutoMapper;
using RestaurantReservation.Api.Contracts.Models;

namespace RestaurantReservation.Api.Profiles;

public class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {
        CreateMap<Restaurant, RestaurantDto>();
        CreateMap<Restaurant, RestaurantWithEmployeesDto>();
        CreateMap<Restaurant, RestaurantWithMenuItemsDto>();
        CreateMap<RestaurantIsolatedDto, Restaurant>();
        CreateMap<Restaurant, RestaurantIsolatedDto>();

    }
}
