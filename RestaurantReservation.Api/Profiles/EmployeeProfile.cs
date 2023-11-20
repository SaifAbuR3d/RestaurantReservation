using AutoMapper;
using RestaurantReservation.Api.Models;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeWithOrdersDto>();
            CreateMap<EmployeeForCreationOrUpdate, Employee>();
            CreateMap<Employee, EmployeeForCreationOrUpdate>();

        }
    }
}
