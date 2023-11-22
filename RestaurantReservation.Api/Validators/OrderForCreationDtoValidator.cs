﻿using FluentValidation;
using RestaurantReservation.Api.Models;

namespace RestaurantReservation.Api.Validators
{
    public class OrderForCreationDtoValidator: AbstractValidator<OrderForCreationDto>
    {
        public OrderForCreationDtoValidator()
        {
            RuleFor(x => x.EmployeeId)
                .ValidId();

            RuleFor(x => x.OrderDate)
                .ValidOneMonthInFutureDate(); 
        }
    }
}