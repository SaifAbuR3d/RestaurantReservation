using FluentValidation;
using RestaurantReservation.Api.Models;

namespace RestaurantReservation.Api.Validators
{
    public class OrderItemForCreationOrUpdateDtoValidator : AbstractValidator<OrderItemForCreationOrUpdateDto>
    {
        public OrderItemForCreationOrUpdateDtoValidator()
        {
            RuleFor(x => x.MenuItemId)
                .ValidId();

            RuleFor(x => x.Quantity)
                .NotEmpty().NotNull()
                .InclusiveBetween(1, 1000); 
                
        }
    }
}
