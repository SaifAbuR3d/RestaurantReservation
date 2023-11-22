using FluentValidation;
using RestaurantReservation.Api.Models;

namespace RestaurantReservation.Api.Validators
{
    public class RestaurantIsolatedDtoValidator : AbstractValidator<RestaurantIsolatedDto>
    {
        public RestaurantIsolatedDtoValidator()
        {
            RuleFor(x => x.Name)
                .ValidName(); 

            RuleFor(x => x.PhoneNumber)
                .ValidPhoneNumber();

            RuleFor(x => x.OpenningHours)
                .NotEmpty().NotNull(); 

            RuleFor(x => x.Address)
                .NotEmpty().NotNull();
        }
    }
}
