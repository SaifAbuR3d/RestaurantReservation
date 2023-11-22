using FluentValidation;
using RestaurantReservation.Api.Models;

namespace RestaurantReservation.Api.Validators;

public class CustomerForUpdateDtoValidator : AbstractValidator<CustomerForUpdateDto>
{
    public CustomerForUpdateDtoValidator()
    {
        RuleFor(x => x.FirstName).ValidName();

        RuleFor(x => x.LastName).ValidName();

        RuleFor(x => x.Email)
            .NotNull().NotEmpty()
            .EmailAddress();

        RuleFor(x => x.PhoneNumber).ValidPhoneNumber(); 
    }
}