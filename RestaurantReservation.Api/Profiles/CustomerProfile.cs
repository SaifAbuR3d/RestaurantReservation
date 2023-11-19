using AutoMapper;
using RestaurantReservation.Api.Models;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, Models.CustomerWithoutReservationsDto>();
        CreateMap<Customer, Models.CustomerDto>();
        CreateMap<Models.CustomerForCreationDto, Customer>();
        CreateMap<CustomerForUpdateDto, Customer>(); 
        CreateMap<Customer, CustomerForUpdateDto>();
    }
}
