using RestaurantReservation.Db.Authentication;

namespace AuthenticationService;

public interface IJwtTokenGenerator
{
    /// <summary>
    /// Generate a jwt token
    /// </summary>
    /// <param name="user">ApplicationUser instance</param>
    /// <param name="userRoles">List of user roles</param>
    /// <returns>jwt token as a string</returns>
    string? GenerateToken(ApplicationUser user, IList<string> userRoles);
}