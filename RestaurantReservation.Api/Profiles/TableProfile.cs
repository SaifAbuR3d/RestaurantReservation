using RestaurantReservation.Domain.Entities;
using AutoMapper;
using RestaurantReservation.Api.Contracts.Models;

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
