using FluentValidation;
using RestaurantReservation.Api.Contracts.Models;

namespace RestaurantReservation.Api.Validators;

public class ReservationForCreationOrUpdateDtoValidator : AbstractValidator<ReservationForCreationOrUpdateDto>
{
    public ReservationForCreationOrUpdateDtoValidator()
    {
        RuleFor(x => x.CustomerId)
            .ValidId(); 

        RuleFor(x => x.RestaurantId)
            .ValidId();

        RuleFor(x => x.TableId)
            .ValidId();

        RuleFor(x => x.PartySize)
            .NotEmpty().NotNull()
            .InclusiveBetween(1, 30);

        RuleFor(x => x.ReservationDate)
            .ValidOneMonthInFutureDate(); 

    }

}
