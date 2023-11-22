using FluentValidation;
using RestaurantReservation.Api.Models;

namespace RestaurantReservation.Api.Validators
{
    public class MenuItemForCreationDtoValidator : AbstractValidator<MenuItemForCreationDto>
    {
        public MenuItemForCreationDtoValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().NotNull()
                .Length(1, 300); 

            RuleFor(x => x.Name).ValidName();

            RuleFor(x => x.Price)
                .NotEmpty().NotNull();
        }
    }
}
