using AutoMapper;
using RestaurantReservation.Api.Contracts.Models;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerWithoutReservationsDto>();
        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerForCreationDto, Customer>();
        CreateMap<CustomerForUpdateDto, Customer>(); 
        CreateMap<Customer, CustomerForUpdateDto>();
    }
}
