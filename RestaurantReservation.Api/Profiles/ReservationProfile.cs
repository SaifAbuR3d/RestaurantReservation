using AutoMapper;
using RestaurantReservation.Api.Models;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Profiles;

public class ReservationProfile : Profile
{
    public ReservationProfile()
    {
        CreateMap<Reservation, ReservationDto>();
        CreateMap<ReservationForCreationOrUpdateDto, Reservation>();
        CreateMap<Reservation, ReservationForCreationOrUpdateDto>();
        CreateMap<Reservation, ReservationWithOrdersDto>();
    }
}
