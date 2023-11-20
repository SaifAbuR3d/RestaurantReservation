using RestaurantReservation.Api.Models;
using RestaurantReservation.Domain.Entities;
using AutoMapper; 
namespace RestaurantReservation.Api.Profiles;

public class TableProfile : Profile
{
    public TableProfile()
    {
        CreateMap<Table, TableDto>();
        CreateMap<TableForCreationOrUpdateDto, Table>();
        CreateMap<Table, TableForCreationOrUpdateDto>();


    }
}
