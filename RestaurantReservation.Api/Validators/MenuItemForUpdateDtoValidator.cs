using FluentValidation;
using RestaurantReservation.Api.Models;

namespace RestaurantReservation.Api.Validators
{
    public class MenuItemForUpdateDtoValidator : AbstractValidator<MenuItemForUpdateDto>
    {
        public MenuItemForUpdateDtoValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().NotNull()
                .Length(1, 300);

            RuleFor(x => x.Name).ValidName();

            RuleFor(x => x.Price)
                .NotEmpty().NotNull();

            RuleFor(x => x.RestaurantId)
                .ValidId();
        }
    }
}
