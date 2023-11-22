using FluentValidation;
using System.Text.RegularExpressions;

namespace RestaurantReservation.Api.Validators;

public static class MyCustomValidators
{
    public static IRuleBuilderOptions<T, string> ValidName<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
         .NotNull().NotEmpty().WithMessage("'{PropertyName}' is required.")
         .Matches(@"^[A-Za-z\s]*$").WithMessage("'{PropertyName}' should only contain letters.")
         .Length(2, 20);

    }

    public static IRuleBuilderOptions<T, string> ValidPhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
         .NotNull().NotEmpty().WithMessage("Phone Number is required.")
         .Length(10)
         .Matches(new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$"))
         .WithMessage("PhoneNumber should contain exactly 10 numerical digits");
    }

    public static IRuleBuilderOptions<T, int> ValidId<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder
         .NotEmpty()
         .NotNull().WithMessage("'{PropertyName}' is required.")
         .InclusiveBetween(1, 1_000_000_000);
    }

    public static IRuleBuilderOptions<T, DateTime> ValidOneMonthInFutureDate<T>(this IRuleBuilder<T, DateTime> ruleBuilder)
    {
        return ruleBuilder
         .NotEmpty().NotNull()
         .GreaterThanOrEqualTo(DateTime.UtcNow)
         .WithMessage("Reservation Date date should be in the future")
         .LessThanOrEqualTo(DateTime.UtcNow.AddMonths(1))
         .WithMessage("Reservation Date date should be at most 1 month from now");
    }



}

