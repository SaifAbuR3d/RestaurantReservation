using FluentValidation;
using System.Text.RegularExpressions;

namespace RestaurantReservation.Api.Validators;

/// <summary>
/// Set of Extension methods for IRuleBuilder
/// </summary>
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
         .WithMessage("'{PropertyName}' should be in the future")
         .LessThanOrEqualTo(DateTime.UtcNow.AddMonths(1))
         .WithMessage("'{PropertyName}' should be at most 1 month from now");
    }
    /// <summary>
    /// validate the password is Minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ruleBuilder"></param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, string> StrongPassword<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().NotNull()
            .MinimumLength(8)
            .WithMessage("Password Must be at least 8 characters")
            .Matches("[A-Z]").WithMessage("Password must include UPPERCASE letters")
            .Matches("[a-z]").WithMessage("Password must include lowercase letters")
            .Matches("[0-9]").WithMessage("Password must include digits")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must include special characters");
    }
}

