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

            RuleFor(x => x.Position).ValidName();
        }
    }
}
