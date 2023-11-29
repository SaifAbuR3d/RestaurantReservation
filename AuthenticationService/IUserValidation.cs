using RestaurantReservation.Db.Authentication;

namespace AuthenticationService;

public interface IUserValidation
{
    /// <summary>
    /// Validate User Credentials
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns>A tuple of ApplicationUser and List of user roles if valid credentials, otherwise null</returns>
    Task<(ApplicationUser, IList<string>)?> Validate(string username, string password);
}