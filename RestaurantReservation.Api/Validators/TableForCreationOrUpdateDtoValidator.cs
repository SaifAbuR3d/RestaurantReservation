using FluentValidation;
using RestaurantReservation.Api.Contracts.Models;

namespace RestaurantReservation.Api.Validators;

public class TableForCreationOrUpdateDtoValidator : AbstractValidator<TableForCreationOrUpdateDto>
{
    public TableForCreationOrUpdateDtoValidator()
    {
        RuleFor(x => x.Capacity)
            .NotEmpty().NotNull()
            .InclusiveBetween(1, 30); 
    }
}
