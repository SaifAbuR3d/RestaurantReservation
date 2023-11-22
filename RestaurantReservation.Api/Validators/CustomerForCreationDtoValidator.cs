using FluentValidation;
using RestaurantReservation.Api.Models;

namespace RestaurantReservation.Api.Validators;

public class CustomerForCreationDtoValidator : AbstractValidator<CustomerForCreationDto>
{
    public CustomerForCreationDtoValidator()
    {
        RuleFor(x => x.FirstName).ValidName();

        RuleFor(x => x.LastName).ValidName(); 

        RuleFor(x => x.Email)
            .NotNull().NotEmpty()
            .EmailAddress();

    }
}
