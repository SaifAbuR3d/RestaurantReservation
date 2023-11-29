using Microsoft.AspNetCore.Identity;
using RestaurantReservation.Db.Authentication;

namespace AuthenticationService;

public class UserValidation : IUserValidation
{
    private readonly UserManager<ApplicationUser> _userManager;
    public UserValidation(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<(ApplicationUser, IList<string>)?> Validate(string username, string password)
    {
        var user = (await _userManager.FindByNameAsync(username));
        if (user == null)
        {
            return null;
        }

        bool passwordMatches = await _userManager.CheckPasswordAsync(user, password);
        if (!passwordMatches)
        {
            return null;
        }

        var userRoles = await _userManager.GetRolesAsync(user);
        return (user, userRoles);
    }
}
