using FluentValidation;
using RestaurantReservation.Api.Contracts.Models.Authentication;

namespace RestaurantReservation.Api.Validators;

public class LoginRequestDtoValidator : AbstractValidator<LoginRequestDto>
{
    public LoginRequestDtoValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().NotNull()
            .WithMessage("User Name is required");

        RuleFor(x => x.Password)
            .StrongPassword();
    }
}
