using FluentValidation;
using RestaurantReservation.Api.Models;

namespace RestaurantReservation.Api.Validators
{
    public class EmployeeForCreationOrUpdateValidator : AbstractValidator<EmployeeForCreationOrUpdate>
    {
        public EmployeeForCreationOrUpdateValidator()
        {
            RuleFor(x => x.RestaurantId).ValidId(); 

            RuleFor(x => x.FirstName).ValidName(); 

            RuleFor(x => x.LastName).ValidName();

            // rules for 'position' property are similar to names
            RuleFor(x => x.Position).ValidName();
        }
    }
}
