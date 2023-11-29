using FluentValidation;
using RestaurantReservation.Api.Contracts.Models.Authentication;

namespace RestaurantReservation.Api.Validators;

public class RegisterRequestDtoValidator : AbstractValidator<RegisterRequestDto>
{
    public RegisterRequestDtoValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().NotNull()
            .WithMessage("User Name is required");

        RuleFor(x => x.Email)
            .NotEmpty().NotNull()
            .WithMessage("Email Address is required")
            .EmailAddress()
            .WithMessage("Must be a valid Email");

        RuleFor(x => x.Password)
            .Cascade(CascadeMode.Stop)
            .StrongPassword();

    }
}
